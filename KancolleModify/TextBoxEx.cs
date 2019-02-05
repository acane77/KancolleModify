using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KancolleModify
{
    class TextBoxEx : TextBox
    {
        public event EventHandler OnLostFocusEx;
        public event EventHandler OnFocus;

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            OnLostFocusEx?.Invoke(this, e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            OnFocus?.Invoke(this, e);
        }
    }
}
