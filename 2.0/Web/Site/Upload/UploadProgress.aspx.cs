#region License
/*

File Upload HTTP module for ASP.Net (v 2.0)
Copyright (C) 2007-2008 Darren Johnstone (http://darrenjohnstone.net)

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

*/
#endregion

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using darrenjohnstone.net.FileUpload;

namespace FileUploadV2
{
    /// <summary>
    /// The upload progress page. This is required to populate the IFrame or popup window
    /// for the progress bar.
    /// </summary>
    public partial class UploadProgress : Page
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            Response.AppendHeader( "Cache-Control", "no-cache" );
            Response.AppendHeader( "Cache-Control", "private" );
            Response.AppendHeader( "Cache-Control", "no-store" );
            Response.AppendHeader( "Cache-Control", "must-revalidate" );
            Response.AppendHeader( "Cache-Control", "max-stale=0" );
            Response.AppendHeader( "Cache-Control", "post-check=0" );
            Response.AppendHeader( "Cache-Control", "pre-check=0" );
            Response.AppendHeader( "Pragma", "no-cache" );
            Response.AppendHeader( "Keep-Alive", "timeout=3, max=993" );
            Response.AppendHeader( "Expires", "Mon, 26 Jul 1997 05:00:00 GMT" );
        }

        protected override void OnPreRender( EventArgs e )
        {
            base.OnPreRender( e );

            var status = UploadManager.Instance.Status;

            if ( status != null )
            {
                upProgressBar.Width = new Unit( status.ProgressPercent, UnitType.Percentage );

                if ( status.ProgressPercent > 0 )
                    lblStatus.Text = "Загрузка: " + status.CurrentFile + " " + status.ProgressPercent + "%";
                else
                    lblStatus.Text = "Ожидание загрузки";
            }
            else
                lblStatus.Text = "Ожидание загрузки";
        }
    }
}
