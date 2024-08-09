using System.Security.Cryptography;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Text.Json;
using Telerik.WinControls.UI;

namespace app_winforsm;
internal partial class AngularWebControl : UserControl
{
    private WebView2? _webView;

    public event EventHandler? OnChartItemClick;
    private dynamic? Data { get; set; }
    private RadLabel? Title { get; set; }

    public AngularWebControl()
    {
        InitializeComponent();
    }
    public async void LoadData(string title, dynamic data)
    {
        if (Title == null)
        {
            Title = new RadLabel
            {
                Text = title,
                Dock = DockStyle.Top,
                Width = this.Width,
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ThemeName = "Windows11"
            };


            this.Controls.Add(Title);

            Title.MouseUp += Title_MouseUp;
        }

        this.Title.Text = title;

        if (_webView == null)
        {
            _webView = new WebView2
            {
                Visible = true,
                Dock = DockStyle.Fill
            };

            this.Controls.Add(_webView);

            var userDataFolder1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"AngularWinFormsApp_{this.Name}");
         
            // Avoid sharing data in sessions 
            var environment1 = await CoreWebView2Environment.CreateAsync(userDataFolder: userDataFolder1);

            await _webView.EnsureCoreWebView2Async(environment1);

            _webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;

            // Add an event handler for custom events
            _webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            _webView.CoreWebView2.Navigate($"{AngularDefs.Url}{AngularDefs.RouteGraph}");

            if (OnChartItemClick != null)
            {
                await _webView.CoreWebView2.ExecuteScriptAsync(@"
                    window.addEventListener('MyClick', function(event) {
                        window.chrome.webview.postMessage(event.detail.message);
                    });
                ");
            }
        }

        this.Data = data;
    }

    private void Title_MouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ShowWebViewConsole();
        }
    }

    // Event handler to handle messages received from the WebView2
    private void CoreWebView2_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
    {
        // Retrieve the message from the event
        var message = e.TryGetWebMessageAsString();

        // Display the message or perform any action
        OnChartItemClick?.Invoke(message, EventArgs.Empty);
    }
    private async void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        if (_webView == null) return;

        _webView.Visible = true;

        if (!e.IsSuccess)
        {
            switch (e.WebErrorStatus)
            {

                case CoreWebView2WebErrorStatus.ConnectionAborted:
                    ShowErrorMessage("Connection refused. Please make sure the server is running and try again.");
                    break;
                case CoreWebView2WebErrorStatus.Unknown:
                case CoreWebView2WebErrorStatus.CertificateCommonNameIsIncorrect:
                case CoreWebView2WebErrorStatus.CertificateExpired:
                case CoreWebView2WebErrorStatus.ClientCertificateContainsErrors:
                case CoreWebView2WebErrorStatus.CertificateRevoked:
                case CoreWebView2WebErrorStatus.CertificateIsInvalid:
                case CoreWebView2WebErrorStatus.ServerUnreachable:
                case CoreWebView2WebErrorStatus.Timeout:
                case CoreWebView2WebErrorStatus.ErrorHttpInvalidServerResponse:
                case CoreWebView2WebErrorStatus.ConnectionReset:
                case CoreWebView2WebErrorStatus.Disconnected:
                case CoreWebView2WebErrorStatus.CannotConnect:
                case CoreWebView2WebErrorStatus.HostNameNotResolved:
                case CoreWebView2WebErrorStatus.OperationCanceled:
                case CoreWebView2WebErrorStatus.RedirectFailed:
                case CoreWebView2WebErrorStatus.UnexpectedError:
                case CoreWebView2WebErrorStatus.ValidAuthenticationCredentialsRequired:
                case CoreWebView2WebErrorStatus.ValidProxyAuthenticationRequired:
                default:
                    ShowErrorMessage("An error occurred while loading the page.");
                    break;
            }
            return;
        }

        var jsonData = JsonSerializer.Serialize(Data);

        var script = $"window.{AngularDefs.ChartVerb}({jsonData});";

        await _webView.CoreWebView2.ExecuteScriptAsync(script);
    }

    private void ShowErrorMessage(string message)
    {
        if (_webView == null) return;

        var htmlContent = $@"
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f8d7da;
                color: #721c24;
                padding: 20px;
                text-align: center;
            }}
            .container {{
                border: 1px solid #f5c6cb;
                border-radius: 5px;
                padding: 20px;
                background-color: #f8d7da;
                display: inline-block;
            }}
            h1 {{
                font-size: 24px;
                margin-bottom: 10px;
            }}
            p {{
                font-size: 18px;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Error while accessing {AngularDefs.Url}</h1>
            <p>{message}</p>
        </div>
    </body>
    </html>";

        _webView.NavigateToString(htmlContent);
    }

    // Method to show the WebView console
    public void ShowWebViewConsole()
    {
        _webView?.CoreWebView2.OpenDevToolsWindow();
    }
}