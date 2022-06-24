using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculatriceProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
    
        private string operation;
        private double nbre1;
        private double nbre2;
       
      
          private ObservableCollection<string>? _historique;
        public ObservableCollection<string> historique
        {
            get
            {
                if (_historique == null) _historique = new ObservableCollection<string>();
                return _historique;
            }
        }
      
        
       
       
        public MainWindow()
        {
           
            InitializeComponent();
            operation = "";
            nbre1 = 0;
            nbre2 = 0;




        }

      

        private void Button_Click(Object sender, RoutedEventArgs e)
        {
          Button btn = (Button)sender;
           MessageBox.Show("Button cliqué:" + btn.Content);


       }
   
        private void  Button_Click_Number(Object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ZoneNumber.Text += btn.Content;

          
        }
        private void Button_Click_Plus_Moins(Object sender, RoutedEventArgs e)
        {
            Button plusMoins = (Button)sender;
            double nbconv = Convert.ToDouble(ZoneNumber.Text);
           
                nbconv = nbconv * (-1);
            ZoneNumber.Text = nbconv.ToString();




        }
        private void Button_Click_Sup(Object sender, RoutedEventArgs e) {
            if ((ZoneNumber.Text).Length > 1)
               
            {
                string newText = (ZoneNumber.Text).Remove((ZoneNumber.Text).Length - 1);
                ZoneNumber.Text = newText;

            }
            
            if ((ZoneNumber.Text).Length == 1)
            {
                ZoneNumber.Text = "0";

            }
           


        }
     
     


        private void Button_Click_Operateur(Object sender, RoutedEventArgs e)
        {
            Button btnOp = (Button)sender;
            operation += btnOp.Content;
            nbre1 = Convert.ToDouble(ZoneNumber.Text);
            ZoneTextOperation.Text = ZoneNumber.Text + btnOp.Content;
            ZoneNumber.Text = "";
          

         
        }

        private void Button_Click_C(Object sender, RoutedEventArgs e)
        {
            Button btnC = (Button)sender;
            ZoneNumber.Text = "0";
            ZoneTextOperation.Text ="";

        }
        private void Button_Click_CE(Object sender, RoutedEventArgs e)
        {
            Button btnCE = (Button)sender;
            ZoneNumber.Text = "0";
          

        }
        private void Button_Click_Egal(Object sender, RoutedEventArgs e)
        {
            //Button btnOp = (Button)sender;
            //ZoneNumber.Text += btnOp.Content;
            DataContext = this;
            switch (operation)
            {
                case "+":
                    nbre2 = Convert.ToDouble(ZoneNumber.Text);
                    ZoneNumber.Text = (nbre1 + Convert.ToDouble(ZoneNumber.Text)).ToString();
                   
                    ZoneTextOperation.Text = (nbre1 + "+" + nbre2).ToString() + "= " + ZoneNumber.Text;

                    historique.Add(ZoneTextOperation.Text);
                    operation = "";

                    break;
                case "-":

                    nbre2 = Convert.ToDouble(ZoneNumber.Text);
                    ZoneNumber.Text = (nbre1 - Convert.ToDouble(ZoneNumber.Text)).ToString();

                    ZoneTextOperation.Text = (nbre1 + "-" + nbre2).ToString() + "= " + ZoneNumber.Text;

                    historique.Add(ZoneTextOperation.Text);
                    operation = "";

                    break;
                case "/":


                    nbre2 = Convert.ToDouble(ZoneNumber.Text);
                    if(Convert.ToDouble(ZoneNumber.Text)==0)
                    {
                        MessageBox.Show("oups division par 0 impossible:" );

                    }
                    else
                    {
                        ZoneNumber.Text = (nbre1 / Convert.ToDouble(ZoneNumber.Text)).ToString();
                        ZoneTextOperation.Text = (nbre1 + "/" + nbre2).ToString() + "= " + ZoneNumber.Text;

                        historique.Add(ZoneTextOperation.Text);

                    }
                  

                  
                    operation = "";
                    break;
                case "x":

                    nbre2 = Convert.ToDouble(ZoneNumber.Text);
                    ZoneNumber.Text = (nbre1 * Convert.ToDouble(ZoneNumber.Text)).ToString();

                    ZoneTextOperation.Text = (nbre1 + "*" + nbre2).ToString() + "= " + ZoneNumber.Text;

                    historique.Add(ZoneTextOperation.Text);
                    operation = "";
                    break;


            }

           

        }

       
    }
  
}
