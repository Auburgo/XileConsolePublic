﻿using System;
using Terminal.Gui;

//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.18.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace XileConsole
{
    public partial class InventoryView : Terminal.Gui.Window
    {
        private Terminal.Gui.FrameView inventoryBorder;

        private Terminal.Gui.FrameView statsBorder;

        private Terminal.Gui.Label totalValueInChaos;

        private Terminal.Gui.Label totalValueInDivine;

        private Terminal.Gui.Button backButton;

        private Terminal.Gui.TableView tableView;

        private void InitializeComponent()
        {
            this.backButton = new Terminal.Gui.Button();
            this.totalValueInDivine = new Terminal.Gui.Label();
            this.totalValueInChaos = new Terminal.Gui.Label();
            this.statsBorder = new Terminal.Gui.FrameView();
            this.tableView = new Terminal.Gui.TableView();
            this.inventoryBorder = new Terminal.Gui.FrameView();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.Border.BorderBrush = Terminal.Gui.Color.Blue;
            this.Border.Effect3D = false;
            this.Border.Effect3DBrush = null;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Title = "";
            this.inventoryBorder.Width = 78;
            this.inventoryBorder.Height = 27;
            this.inventoryBorder.X = 0;
            this.inventoryBorder.Y = 0;
            this.inventoryBorder.Data = "inventoryBorder";
            this.inventoryBorder.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.inventoryBorder.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.inventoryBorder.Border.Effect3D = false;
            this.inventoryBorder.Border.Effect3DBrush = null;
            this.inventoryBorder.Border.DrawMarginFrame = true;
            this.inventoryBorder.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.inventoryBorder.Title = "Inventory";
            this.Add(this.inventoryBorder);
            this.tableView.Width = 76;
            this.tableView.Height = 25;
            this.tableView.X = 0;
            this.tableView.Y = 0;
            this.tableView.Data = "tableView";
            this.tableView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.tableView.FullRowSelect = true;
            this.tableView.Style.AlwaysShowHeaders = true;
            this.tableView.Style.ExpandLastColumn = true;
            this.tableView.Style.InvertSelectedCellFirstCharacter = false;
            this.tableView.Style.ShowHorizontalHeaderOverline = true;
            this.tableView.Style.ShowHorizontalHeaderUnderline = true;
            this.tableView.Style.ShowVerticalCellLines = true;
            this.tableView.Style.ShowVerticalHeaderLines = true;
            
            this.statsBorder.Width = 40;
            this.statsBorder.Height = 27;
            this.statsBorder.X = 78;
            this.statsBorder.Y = 0;
            this.statsBorder.Data = "statsBorder";
            this.statsBorder.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.statsBorder.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.statsBorder.Border.Effect3D = false;
            this.statsBorder.Border.Effect3DBrush = null;
            this.statsBorder.Border.DrawMarginFrame = true;
            this.statsBorder.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.statsBorder.Title = "Stats";
            this.Add(this.statsBorder);
            this.totalValueInChaos.Width = 4;
            this.totalValueInChaos.Height = 1;
            this.totalValueInChaos.X = 2;
            this.totalValueInChaos.Y = 1;
            this.totalValueInChaos.Data = "totalValueInChaos";
            this.totalValueInChaos.Text = "Total Value (chaos): 999";
            this.totalValueInChaos.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.statsBorder.Add(this.totalValueInChaos);
            this.totalValueInDivine.Width = 4;
            this.totalValueInDivine.Height = 1;
            this.totalValueInDivine.X = 2;
            this.totalValueInDivine.Y = 2;
            this.totalValueInDivine.Data = "totalValueInDivine";
            this.totalValueInDivine.Text = "Total Value (divine): 999";
            this.totalValueInDivine.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.statsBorder.Add(this.totalValueInDivine);
            this.backButton.Width = 8;
            this.backButton.Height = 1;
            this.backButton.X = 1;
            this.backButton.Y = 27;
            this.backButton.Data = "backButton";
            this.backButton.Text = "Back";
            this.backButton.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.backButton.IsDefault = false;
            this.Add(this.backButton);
        }
    }
}
