using System.Text.Json;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace app_winforsm;

public partial class FormMain : RadForm
{
    private readonly AngularWebControl? _angularWebControl;

    public FormMain()
    {
        InitializeComponent();

        // Load the AngularWebControl programatically

        _angularWebControl = new AngularWebControl { Name = "_angularWebControl" };
        _angularWebControl.Dock = DockStyle.Fill;

        splitPanel1.Controls.Add(_angularWebControl);

        // Subscribe to the OnChartItemClick event
        _angularWebControl.OnChartItemClick += AngularWebControl_OnChartItemClick;

        LoadData();
    }

    private void AngularWebControl_OnChartItemClick(object? sender, EventArgs e)
    {
        if (sender is null)
            return;

        var message =
            JsonSerializer.Deserialize<Message>(sender.ToString() ?? throw new Exception("Data is not a json."));

        RadMessageBox.ThemeName = "Windows11";
        RadMessageBox.Show($"You clicked on {message.Category} with value {message.Value}", "Chart Item Clicked",
            MessageBoxButtons.OK, RadMessageIcon.Info);
    }

    private void LoadData()
    {
        var data = new[]
        {
            new { name = "Gastroenteritis", value = 40, color = "red" },
            new { name = "Appendicitis", value = 25, color = "blue" },
            new { name = "Cholecystitis", value = 15, color = "green" },
            new { name = "Pancreatitis", value = 10, color = "yellow" },
            new { name = "Diverticulitis", value = 10, color = "orange" }
        };

        _angularWebControl?.LoadData("Common gastro deseases in hospitals", data);

        var dataAges = new[]
        {
            new { name = "0-10", value = 1, color = "red" },
            new { name = "11-20", value = 10, color = "blue" },
            new { name = "21-30", value = 20, color = "green" },
            new { name = "31-40", value = 25, color = "yellow" },
            new { name = "41-50", value = 15, color = "orange" },
            new { name = "51-60", value = 20, color = "purple" },
            new { name = "61-70", value = 8, color = "brown" },
            new { name = "71+", value = 7, color = "pink" }
        };

        this.angularWebControl1.LoadData("Patiant ages in gastro deseases", dataAges);
    }
}