using LogosoftProjekat.EF;
using LogosoftProjekat.EntityModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LogosoftProjekat.Helper
{
    public static class Authentication
    {
        public static readonly string LoggedUser = "logged_user";

        public static void SetLoggedUser(this HttpContext context, Identity user, bool savedInCookie = false)
        {

            MojContext db = context.RequestServices.GetService<MojContext>();

            string oldToken = context.Request.GetCookieJson<string>(LoggedUser);
            if (oldToken != null)
            {
                AuthorizationToken tempToken = db.AuthorizationToken.FirstOrDefault(x => x.Value == oldToken);
                if (tempToken != null)
                {
                    db.AuthorizationToken.Remove(tempToken);
                    db.SaveChanges();
                }
            }

            if (user != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AuthorizationToken.Add(new AuthorizationToken
                {
                    Value=token,
                    UserId=user.UserId,
                    LoggedTime=DateTime.Now
             
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LoggedUser, token);
            }
        }

        public static string GetCurrentToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LoggedUser);
        }

        public static Identity GetLoggedUser(this HttpContext context)
        {
            MojContext db = context.RequestServices.GetService<MojContext>();

            string token = context.Request.GetCookieJson<string>(LoggedUser);
            if (token == null)
                return null;

            return db.AuthorizationToken
                .Where(x => x.Value==token)
                .Select(s => s.User)
                .SingleOrDefault();

        }
    }
}
