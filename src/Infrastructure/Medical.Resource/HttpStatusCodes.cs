using System.Net;

namespace Medical.Resource
{
    public static class HttpStatusCodes
    {
        //200
        public static int OK => (int)HttpStatusCode.OK;

        //202
        public static int ACCEPTED => (int)HttpStatusCode.Accepted;

        //400
        public static int BAD_REQUEST => (int)HttpStatusCode.BadRequest;

        //401
        public static int UNAUTHORIZED => (int)HttpStatusCode.Unauthorized;

        //403
        public static int FORBIDDEN => (int)HttpStatusCode.Forbidden;

        //404
        public static int NOT_FOUND => (int)HttpStatusCode.NotFound;

        //500
        public static int INTERNAL_SERVER_ERROR => (int)HttpStatusCode.InternalServerError;

    }
}
