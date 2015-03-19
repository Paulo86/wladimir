using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Remarca.Wladimir.UI.WindowsForms
{
   public static class MetodosExtencao
    {
       public static void SomenteLeitura(this Form formulario)
       {
           foreach (var clt in formulario.Controls)
           {
               if (clt is TextBox)               
                   (clt as TextBox).ReadOnly = true;

               if (clt is ComboBox)
                   (clt as ComboBox).Enabled = true;               
           }
       }
    }
}
