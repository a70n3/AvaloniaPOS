using Avalonia.Controls;
using Avalonia.POS.ViewModels;

namespace Avalonia.POS;

public partial class MainWindow : Window
{
    private RemoveItemDialog _removeItemDialog;
    public MainWindow()
    {
        InitializeComponent();
        
    }

    protected override void OnInitialized()
    {
        if (DataContext is MainViewModel vm)
        {
            vm.OnRemoveItemButtonPressed += ShowRemoveItemDialog;
            vm.OnItemWasRemove += CloseRemoveItemDialog;
        }
    }

    private void ShowRemoveItemDialog()
    {
        _removeItemDialog = new RemoveItemDialog();
        _removeItemDialog.DataContext = this.DataContext;
        _removeItemDialog.ShowDialog(this);

    }

    private void CloseRemoveItemDialog()
    {
        if(_removeItemDialog.IsActive)
            _removeItemDialog.Close();
            _removeItemDialog = null;
    }
}