using System;

namespace Pripev.Web
{
    [AttributeUsage( AttributeTargets.All )]
    public class PageAttribute : Attribute
    {
        public PageAttribute()
        {
            CreateUser = true;
        }

        //TODO: Why set is not used?
        public bool DoSValidation { get; set; }
        public bool CreateUser { get; set; }
    }
}
