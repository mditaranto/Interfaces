using System.Text.RegularExpressions;

namespace Calculadora.Views;

public partial class CalculadoraPage : ContentPage {
    private bool operated = false;
    private bool needToOperate = false;

    public CalculadoraPage() {
        InitializeComponent();
    }

    private void numberEvent(object sender, EventArgs e) {
        if (operated) {
            newOperation();
        }

        if (labelResult.Text == "0" || labelResult.Text == "0.0") {
            labelResult.Text = "";
        }

        labelResult.Text += ((Button) sender).Text;

        textSize();
    }

    private void operationEvent(object sender, EventArgs e) {
        Button button = (Button) sender;

        if (operated) {
            newOperation();
        }

        if (needToOperate) {
            resultEvent(sender, e);
            labelOperation.Text += button.Text;
            needToOperate = false;
        }

        string symbol = "";
        bool clear = false;

        switch (button.Text) {
            case "AC":
                labelResult.Text = "0";
                labelOperation.Text = "";
                clear = true;
                break;
            case "+":
                symbol = "+";
                break;
            case "−":
                symbol = "−";
                break;
            case "×":
                symbol = "×";
                break;
            case "÷":
                symbol = "÷";
                break;
        }

        if (!clear) {
            labelOperation.Text += labelResult.Text + symbol;
            labelResult.Text = "0";
        }

        textSize();
        needToOperate = true;
    }

    private void resultEvent(object sender, EventArgs e) {
        if (operated) {
            return;
        }

        labelOperation.Text += labelResult.Text;

        string[] operations = Regex.Split(labelOperation.Text, @"(\+|−|×|÷)");
        double result = double.Parse(operations[0]);
        double number = double.Parse(operations[2]);

        switch (operations[1]) {
            case "+":
                result += number;
                break;
            case "−":
                result -= number;
                break;
            case "×":
                result *= number;
                break;
            case "÷":
                result /= number;
                break;
        }

        labelResult.Text = result.ToString();

        operated = true;

        textSize();
    }

    private void textSize() {
        int newSize = 70;
        int size = labelResult.Text.Length;

        if (size > 18) {
            newSize = 32;
        } else if (size > 16) {
            newSize = 40;
        } else if (size > 14) {
            newSize = 50;
        } else if (size > 12) {
            newSize = 55;
        } else if (size > 10) {
            newSize = 60;
        }

        labelResult.FontSize = newSize;
    }

    private void OnSwipeRight(object sender, SwipedEventArgs e) {
        labelResult.Text = labelResult.Text.Substring(0, labelResult.Text.Length - 1);
    }

    private void newOperation() {
        labelOperation.Text = labelResult.Text;
        labelResult.Text = "";
        operated = false;
    }
}
