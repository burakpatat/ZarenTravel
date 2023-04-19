using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DP_Html_2_SB;

public class frmHTMLBuilder : Form
{
	private ArrayList content = new ArrayList();

	private IContainer components;

	private RichTextBox richTextBox1;

	private Button button1;

	private Label label1;

	private Label lblStatus;

	public frmHTMLBuilder()
	{
		this.InitializeComponent();
		this.lblStatus.Text = "Paste your HTML and click on Convert.";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		this.lblStatus.Text = "Building HTML...";
		this.content.Clear();
		string[] lines;
		lines = this.richTextBox1.Lines;
		foreach (string value in lines)
		{
			this.content.Add(value);
		}
		this.Convert();
	}

	private void Convert()
	{
		this.Cursor = Cursors.WaitCursor;
		string text;
		text = "    ";
		try
		{
			this.richTextBox1.Text = "";
			StringBuilder stringBuilder;
			stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("String HTMLBuilder()");
			stringBuilder.AppendLine("{");
			stringBuilder.Append(text + "//Create a new StringBuilder object" + Environment.NewLine + text + "StringBuilder sb = new StringBuilder();" + Environment.NewLine + Environment.NewLine);
			IEnumerator enumerator;
			enumerator = this.content.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2;
				text2 = enumerator.Current.ToString();
				text2.Replace("\\", "\\\\");
				stringBuilder.AppendLine(text + "sb.AppendLine(\"" + text2.Replace("\"", "\\\"") + "\");");
			}
			stringBuilder.Append(Environment.NewLine + text + "return sb.ToString();" + Environment.NewLine);
			stringBuilder.AppendLine("}");
			this.richTextBox1.Text = stringBuilder.ToString();
			Clipboard.SetText(stringBuilder.ToString());
			this.lblStatus.Text = "HTML Builded. (And Copied to Clipboard)";
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
		this.Cursor = Cursors.Default;
	}

	private void richTextBox1_DoubleClick(object sender, EventArgs e)
	{
		this.richTextBox1.SelectAll();
	}

	private void label1_Click(object sender, EventArgs e)
	{
		Process.Start("http://danpesolutions.blogspot.com/");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.components != null)
		{
			this.components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources;
		resources = new System.ComponentModel.ComponentResourceManager(typeof(DP_Html_2_SB.frmHTMLBuilder));
		this.richTextBox1 = new System.Windows.Forms.RichTextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.lblStatus = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.richTextBox1.AcceptsTab = true;
		this.richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
		this.richTextBox1.DetectUrls = false;
		this.richTextBox1.EnableAutoDragDrop = true;
		this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.richTextBox1.Location = new System.Drawing.Point(11, 12);
		this.richTextBox1.Name = "richTextBox1";
		this.richTextBox1.Size = new System.Drawing.Size(469, 292);
		this.richTextBox1.TabIndex = 0;
		this.richTextBox1.Text = "";
		this.richTextBox1.DoubleClick += new System.EventHandler(richTextBox1_DoubleClick);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.button1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 177);
		this.button1.Location = new System.Drawing.Point(300, 310);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(180, 50);
		this.button1.TabIndex = 1;
		this.button1.Text = "Convert";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label1.AutoSize = true;
		this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
		this.label1.Location = new System.Drawing.Point(8, 343);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(99, 14);
		this.label1.TabIndex = 2;
		this.label1.Text = "Danpe Solutions  ©";
		this.label1.Click += new System.EventHandler(label1_Click);
		this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStatus.AutoSize = true;
		this.lblStatus.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 177);
		this.lblStatus.Location = new System.Drawing.Point(11, 310);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(0, 15);
		this.lblStatus.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(492, 366);
		base.Controls.Add(this.lblStatus);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.richTextBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MinimumSize = new System.Drawing.Size(450, 350);
		base.Name = "frmHTMLBuilder";
		this.Text = "C# HTML Builder";
		base.TopMost = true;
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
