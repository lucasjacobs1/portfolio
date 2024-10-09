using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar.NotificationSystem
{
    public static class NotificationController
    {
        public static void Alert(string msg, NotificationSystem.Form_Alert.enmType type)
        {
            NotificationSystem.Form_Alert frm = new NotificationSystem.Form_Alert();
            frm.showAlert(msg, type);
        }
    }

}
