using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permutations
{
	public partial class PermutationsForm : Form
	{
		public PermutationsForm()
		{
			InitializeComponent();
		}

		private void GoButton_Click(object sender, EventArgs e)
		{
			var words = WordsTextBox.Text;//TODO: split
			var permutations = PermutationsTextBox.Text;//TODO: convert to number
			OutputTextBox.Text = "hallo" +
			"\r\n" + words+
			"\r\nPermutations=" + permutations;
			/*For example, suppose the set is {apple, banana, cherry}, then the permutations containing two items are all of the orderings of two items selected from that set. Those permutations are {apple, banana}, {apple, cherry}, {banana, apple}, {banana, cherry}, {cherry, apple}, and {cherry, banana}. Notice that {apple, banana} and {banana, apple} contain the same items in different orders.

Write an extension method that returns a List<List<T>>, holding the permutations of a specified length from an array of items. If the specified length is omitted, return all permutations of all lengths.
*/
		}
	}
}
