
// This file has been generated by the GUI designer. Do not modify.
namespace TraceLab.UI.GTK
{
	public partial class ComponentInfoPage
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.TextView textview1;
		private global::Gtk.Table table1;
		private global::Gtk.Entry authorEntry;
		private global::Gtk.Entry componentNameEntry;
		private global::Gtk.ComboBox componentsDirectoryComboBox;
		private global::Gtk.Entry finalLocationEntry;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView descriptionTextView;
		private global::Gtk.Label label1;
		private global::Gtk.Label label2;
		private global::Gtk.Label label3;
		private global::Gtk.Label label4;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.Entry versionEntry;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget TraceLab.UI.GTK.ComponentInfoPage
			global::Stetic.BinContainer.Attach (this);
			this.Name = "TraceLab.UI.GTK.ComponentInfoPage";
			// Container child TraceLab.UI.GTK.ComponentInfoPage.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(3));
			// Container child vbox2.Gtk.Box+BoxChild
			this.textview1 = new global::Gtk.TextView ();
			this.textview1.Buffer.Text = "Finally define component\'s name, version and optionally provide description.\nNote" +
				", that component\'s Name, Version, Input and Output, and Configuration determines" +
				" its unique ID.";
			this.textview1.Sensitive = false;
			this.textview1.CanFocus = true;
			this.textview1.Name = "textview1";
			this.textview1.Editable = false;
			this.textview1.CursorVisible = false;
			this.textview1.WrapMode = ((global::Gtk.WrapMode)(2));
			this.textview1.LeftMargin = 4;
			this.textview1.RightMargin = 4;
			this.vbox2.Add (this.textview1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.textview1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(6)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(8));
			this.table1.ColumnSpacing = ((uint)(12));
			this.table1.BorderWidth = ((uint)(4));
			// Container child table1.Gtk.Table+TableChild
			this.authorEntry = new global::Gtk.Entry ();
			this.authorEntry.CanFocus = true;
			this.authorEntry.Name = "authorEntry";
			this.authorEntry.IsEditable = true;
			this.authorEntry.InvisibleChar = '●';
			this.table1.Add (this.authorEntry);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.authorEntry]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.componentNameEntry = new global::Gtk.Entry ();
			this.componentNameEntry.CanFocus = true;
			this.componentNameEntry.Name = "componentNameEntry";
			this.componentNameEntry.IsEditable = true;
			this.componentNameEntry.InvisibleChar = '●';
			this.table1.Add (this.componentNameEntry);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.componentNameEntry]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.componentsDirectoryComboBox = global::Gtk.ComboBox.NewText ();
			this.componentsDirectoryComboBox.Name = "componentsDirectoryComboBox";
			this.table1.Add (this.componentsDirectoryComboBox);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.componentsDirectoryComboBox]));
			w4.TopAttach = ((uint)(4));
			w4.BottomAttach = ((uint)(5));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.finalLocationEntry = new global::Gtk.Entry ();
			this.finalLocationEntry.Sensitive = false;
			this.finalLocationEntry.CanFocus = true;
			this.finalLocationEntry.Name = "finalLocationEntry";
			this.finalLocationEntry.IsEditable = false;
			this.finalLocationEntry.InvisibleChar = '●';
			this.table1.Add (this.finalLocationEntry);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.finalLocationEntry]));
			w5.TopAttach = ((uint)(5));
			w5.BottomAttach = ((uint)(6));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.descriptionTextView = new global::Gtk.TextView ();
			this.descriptionTextView.CanFocus = true;
			this.descriptionTextView.Name = "descriptionTextView";
			this.GtkScrolledWindow.Add (this.descriptionTextView);
			this.table1.Add (this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.GtkScrolledWindow]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Component name:");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Author:");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 0F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Version:");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.Yalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Description:");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w11.TopAttach = ((uint)(3));
			w11.BottomAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Components directory:");
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Final location:");
			this.table1.Add (this.label6);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.label6]));
			w13.TopAttach = ((uint)(5));
			w13.BottomAttach = ((uint)(6));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.versionEntry = new global::Gtk.Entry ();
			this.versionEntry.CanFocus = true;
			this.versionEntry.Name = "versionEntry";
			this.versionEntry.IsEditable = true;
			this.versionEntry.InvisibleChar = '●';
			this.table1.Add (this.versionEntry);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1 [this.versionEntry]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table1]));
			w15.Position = 1;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.versionEntry.Changed += new global::System.EventHandler (this.VersionEntryChanged);
			this.componentsDirectoryComboBox.Changed += new global::System.EventHandler (this.componentComboBoxChanged);
			this.componentNameEntry.Changed += new global::System.EventHandler (this.ComponentNameEntryChanged);
			this.authorEntry.Changed += new global::System.EventHandler (this.AuthorEntryChanged);
		}
	}
}