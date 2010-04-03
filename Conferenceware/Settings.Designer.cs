﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conferenceware {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Settings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Settings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Conferenceware.Settings", typeof(Settings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static System.Drawing.Bitmap AttendeeBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("AttendeeBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to conference@acm.illinois.edu.
        /// </summary>
        internal static string EmailFrom {
            get {
                return ResourceManager.GetString("EmailFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a confirmation that you have registered to attend {0} at {1} in {2}. If you have any questions or would like to no longer be registered, please email conference@acm.illinois.edu..
        /// </summary>
        internal static string EventRegistrationConfirmationBodyFormat {
            get {
                return ResourceManager.GetString("EventRegistrationConfirmationBodyFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Event Registration Confirmation for {0}.
        /// </summary>
        internal static string EventRegistrationConfirmationSubjectFormat {
            get {
                return ResourceManager.GetString("EventRegistrationConfirmationSubjectFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is the default frontpage data. What used to be here is now at &lt;a href=&quot;Home/Admin&quot;&gt;/Admin&lt;/a&gt;.
        /// </summary>
        internal static string FrontpageContent {
            get {
                return ResourceManager.GetString("FrontpageContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Conferenceware.
        /// </summary>
        internal static string FrontpageTitle {
            get {
                return ResourceManager.GetString("FrontpageTitle", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap MechmaniaBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("MechmaniaBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to password.
        /// </summary>
        internal static string SmtpAuthenticationPassword {
            get {
                return ResourceManager.GetString("SmtpAuthenticationPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to username.
        /// </summary>
        internal static string SmtpAuthenticationUserName {
            get {
                return ResourceManager.GetString("SmtpAuthenticationUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to localhost.
        /// </summary>
        internal static string SmtpHostname {
            get {
                return ResourceManager.GetString("SmtpHostname", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 25.
        /// </summary>
        internal static string SmtpPort {
            get {
                return ResourceManager.GetString("SmtpPort", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap SpeakerBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("SpeakerBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap SponsorBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("SponsorBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap StaffBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("StaffBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap VolunteerBadgeBackground {
            get {
                object obj = ResourceManager.GetObject("VolunteerBadgeBackground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
