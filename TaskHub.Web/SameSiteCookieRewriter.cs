﻿//namespace TaskHub.Web
//{
//    public static class SameSiteCookieRewriter
//    {
//        public static void FilterSameSiteNoneForIncompatibleUserAgents(object sender)
//        {
//            HttpApplication application = sender as HttpApplication;
//            if(application != null)
//            {
//                var userAgent = application.Context.Request.UserAgent;
//                if(SameSiteSupport.DisallowsSameSiteNone(userAgent))
//                {
//                    application.Response.AddOnSendingHeaders(ContextBoundObject =>
//                    {
//                        var cookies = ContextBoundObject.Response.Cookies;
//                        for(var i = 0; i < cookies.Count; i++)
//                        {
//                            var cookie = cookies[i];
//                            if(cookie.SameSite == SameSiteMode.None)
//                            {
//                                cookie.SameSite = (SameSiteMode)(-1);
//                            }
//                        }
//                    });
//                }
//            }
//        }
//    }
//}
