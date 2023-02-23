namespace FirstProject
{
    public partial class frmFirstProject : Form
    {
        string selectedItemsString = string.Empty;
        List<int> listCheckedIndices = new List<int>();

        public frmFirstProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else if(radioButton2.Checked==true) 
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Load sample data
            var sampleData = new MLModel2.ModelInput()
            {
                Col0=@textBox1.Text,
            };

            //Load model and predict output
            var result = MLModel2.Predict(sampleData);

            if (result.PredictedLabel.ToString().Equals("1"))
            {
                label1.Text = "positive";
            }
            else
            {
                label1.Text = "negative";
            }
        }

        private void cbItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            #region First Method
            //int theIndex = e.Index;
            //string theText = $"Item {cbItems.Items[e.Index]}\r\n";

            //if (e.NewValue == CheckState.Checked)
            //{
            //    selectedItemsString += theText;
            //}
            //else
            //{
            //    selectedItemsString = selectedItemsString.Replace(theText, "");
            //}

            //label3.Text = selectedItemsString;

            #endregion

            #region Second Method
            //selectedItemsString = "";

            //for (int index = 0; index < cbItems.Items.Count; index++)
            //{
            //    if (index == e.Index)
            //    {
            //        if (e.NewValue == CheckState.Checked)
            //        {
            //            selectedItemsString += $"Item {cbItems.Items[e.Index]}\r\n";
            //        }
            //    }

            //    else
            //    {
            //        if (cbItems.GetItemChecked(index))
            //        {
            //            selectedItemsString += $"Item {cbItems.Items[index]}\r\n";
            //        }
            //    }
            //}

            //label3.Text = selectedItemsString;
            #endregion

            #region Third Method

            selectedItemsString = "";

            if (e.NewValue == CheckState.Checked)
            {
                int existIndex = listCheckedIndices
                    .FindIndex(x => x == e.Index);

                if (existIndex == -1)
                {
                    listCheckedIndices.Add(e.Index);
                }
            }
            else
            {
                int existIndex = listCheckedIndices
                    .FindIndex(x => x == e.Index);

                if (existIndex != -1)
                {
                    listCheckedIndices.RemoveAt(existIndex);
                }
            }


            var sortedList = listCheckedIndices
                .OrderBy(x => x)
                .ToList();

            foreach (var index in sortedList)
            {
                selectedItemsString += $"Item {cbItems.Items[index]}\r\n";
            }

            label3.Text = selectedItemsString;

            #endregion
        }

    }
}