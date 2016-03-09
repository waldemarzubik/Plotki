using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using MvvmCross.Binding.Droid.ResourceHelpers;
using Square.Picasso;

namespace Com.Gossip.Droid.Controls
{
    public class CacheImageView : ImageView, ICallback
    {
        private Context _context;
        private int _errorImage;
        private string _imageUrl;
        private int _placeHolder;
        private ITransformation _transformation;
        private Drawable _foreground;
        private bool _refreshMode;

        public CacheImageView(Context context)
            : base(context)
        {
            Initialize(context);
        }

        public CacheImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public CacheImageView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            Initialize(context, attrs);
        }

        protected CacheImageView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (_refreshMode || _imageUrl != value)
                {
                    _imageUrl = value;
                    LoadImage(value);
                }
            }
        }

        public ITransformation Transformation
        {
            get
            {
                return _transformation;
            }
            set
            {
                _transformation = value;
                LoadImage(ImageUrl);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _transformation.Dispose();
                _transformation = null;
            }
            base.Dispose(disposing);
        }

        protected void Initialize(Context context, IAttributeSet attributes = null)
        {
            _context = context;
            ApplyBinding(attributes);
            ReadCustomAttributes(attributes);
        }

        private void ApplyBinding(IAttributeSet attrs = null)
        {
            var typedArray = _context.ObtainStyledAttributes(attrs, MvxAndroidBindingResource.Instance.ImageViewStylableGroupId);
            var numStyles = typedArray.IndexCount;
            for (var i = 0; i < numStyles; ++i)
            {
                var attributeId = typedArray.GetIndex(i);
                if (attributeId == MvxAndroidBindingResource.Instance.SourceBindId)
                {
                    ImageUrl = typedArray.GetString(attributeId);
                }
            }

            typedArray.Recycle();
        }

        public void LoadImage(int resId)
        {
            var request = Picasso.With(_context).Load(resId);
            if (_transformation != null)
            {
                request.Transform(_transformation);
            }

            request.Into(this, this);  
        }

        protected virtual void LoadImage(string imageUri)
        {
            RequestCreator request = Picasso.With(_context).LoadEx(imageUri);
            if (_transformation != null)
            {
                request.Transform(_transformation);
            }

            request.Placeholder(_placeHolder).Error(_errorImage).Into(this, this);  
        }

        private void ReadCustomAttributes(IAttributeSet attrs = null)
        {
            var typedArray = _context.ObtainStyledAttributes(attrs, Resource.Styleable.CacheImageView);
            try
            {
                _placeHolder = typedArray.GetResourceId(Resource.Styleable.CacheImageView_placeholder, 0);
                _errorImage = typedArray.GetResourceId(Resource.Styleable.CacheImageView_errorImage, 0);
                _refreshMode = typedArray.GetBoolean(Resource.Styleable.CacheImageView_refreshMode, false);

                var foreground = typedArray.GetDrawable(Resource.Styleable.CacheImageView_android_foreground);
                if (foreground != null)
                {
                    SetForeground(foreground);
                }
            }
            finally
            {
                typedArray.Recycle();
            }
        }

        public void SetForeground(Drawable drawable)
        {
            if (_foreground == drawable)
            {
                return;
            }

            _foreground = drawable;

            RequestLayout();
            Invalidate();
        }

        protected override bool VerifyDrawable(Drawable who)
        {
            return base.VerifyDrawable(who) || who == _foreground;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            if (_foreground != null)
            {
                _foreground.SetBounds(0, 0, MeasuredWidth, MeasuredHeight);
                Invalidate();
            }
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (_foreground != null)
            {
                _foreground.SetBounds(0, 0, w, h);
                Invalidate();
            }
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            if (_foreground != null)
            {
                _foreground.Draw(canvas);
            }
        }

        public void OnError()
        {
            //TODO: ADD LOGIC HERE
        }

        public void OnSuccess()
        {
            //TODO: ADD LOGIC HERE
        }
    }
}