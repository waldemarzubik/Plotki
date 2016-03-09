using System;
using Java.IO;
using Square.Picasso;

namespace Com.Gossip.Droid
{
    public static class PicassoExtensions
    {
        public static RequestCreator LoadEx(this Picasso request, string imageUri)
        {
            if (string.IsNullOrEmpty(imageUri))
            {
                return request.Load((string)null);
            }

            return (imageUri.ToUpper().StartsWith("HTTP") || imageUri.ToUpper().StartsWith("FILE")) ? request.Load(imageUri) : request.Load(new File(imageUri));
        }
    }
}