//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VooPPointMgr.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class channel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime createdate { get; set; }
        public long created_by { get; set; }
        public string accescode { get; set; }
        public long channel_type { get; set; }
        public bool enable_chat { get; set; }
        public string paypal_email { get; set; }
        public Nullable<long> logo_id { get; set; }
        public string channel_guid { get; set; }
        public long max_user { get; set; }
        public string media_url { get; set; }
        public long channel_mode { get; set; }
        public long video_size { get; set; }
        public string pagename { get; set; }
        public Nullable<long> payment_configuration_id { get; set; }
        public bool is_visible { get; set; }
        public bool show_player { get; set; }
        public long website_id { get; set; }
        public Nullable<long> customer_id { get; set; }
    }
}
