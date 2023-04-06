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
    public partial class MapView : Terminal.Gui.Window
    {
        private Terminal.Gui.ColorScheme greenOnBlack;

        private Terminal.Gui.ColorScheme blueOnBlack;

        private Terminal.Gui.ColorScheme redOnBlack;

        private Terminal.Gui.TabView tabView;

        private Terminal.Gui.FrameView lastMapsBorder;

        private Terminal.Gui.ListView mapList;

        private Terminal.Gui.FrameView lastMapsBorder2;

        private Terminal.Gui.Label totalValuechaos;

        private Terminal.Gui.Label totalValueDivine;

        private Terminal.Gui.Label timeInMapInventory;

        private Terminal.Gui.Label chaosPerHourInventory;

        private Terminal.Gui.TableView tableView;

        private Terminal.Gui.Button deleteMap;

        private Terminal.Gui.FrameView statisticsFrame;

        private Terminal.Gui.FrameView frameView;

        private Terminal.Gui.Label timeInMapStatistic;

        private Terminal.Gui.Label lastMapValueStatistic;

        private Terminal.Gui.Label chaosPerHourStatistic;

        private Terminal.Gui.Label divinePerHourStatistic;

        private Terminal.Gui.FrameView frameView2;

        private Terminal.Gui.Label averageTimePerMap;

        private Terminal.Gui.Label averageValuePerMap;

        private Terminal.Gui.Label averageChaosPerHour;

        private Terminal.Gui.Label averageDivinePerHour;

        private Terminal.Gui.FrameView frameView3;

        private Terminal.Gui.Label trackerTotalTime;

        private Terminal.Gui.Label trackerAvgTimePerMap;

        private Terminal.Gui.Label trackerAvgChaosPerMap;

        private Terminal.Gui.Label trackerChaosPerHour;

        private Terminal.Gui.Label trackerDivinePerHour;

        private Terminal.Gui.Button startButton;

        private Terminal.Gui.Button stopButton;

        private Terminal.Gui.Button resetButton;

        private Terminal.Gui.GraphView graphView;

        private Terminal.Gui.Button backButton;

        private void InitializeComponent()
        {
            this.backButton = new Terminal.Gui.Button();
            this.graphView = new Terminal.Gui.GraphView();
            this.resetButton = new Terminal.Gui.Button();
            this.stopButton = new Terminal.Gui.Button();
            this.startButton = new Terminal.Gui.Button();
            this.trackerDivinePerHour = new Terminal.Gui.Label();
            this.trackerChaosPerHour = new Terminal.Gui.Label();
            this.trackerAvgChaosPerMap = new Terminal.Gui.Label();
            this.trackerAvgTimePerMap = new Terminal.Gui.Label();
            this.trackerTotalTime = new Terminal.Gui.Label();
            this.frameView3 = new Terminal.Gui.FrameView();
            this.averageDivinePerHour = new Terminal.Gui.Label();
            this.averageChaosPerHour = new Terminal.Gui.Label();
            this.averageValuePerMap = new Terminal.Gui.Label();
            this.averageTimePerMap = new Terminal.Gui.Label();
            this.frameView2 = new Terminal.Gui.FrameView();
            this.divinePerHourStatistic = new Terminal.Gui.Label();
            this.chaosPerHourStatistic = new Terminal.Gui.Label();
            this.lastMapValueStatistic = new Terminal.Gui.Label();
            this.timeInMapStatistic = new Terminal.Gui.Label();
            this.frameView = new Terminal.Gui.FrameView();
            this.statisticsFrame = new Terminal.Gui.FrameView();
            this.deleteMap = new Terminal.Gui.Button();
            this.tableView = new Terminal.Gui.TableView();
            this.chaosPerHourInventory = new Terminal.Gui.Label();
            this.timeInMapInventory = new Terminal.Gui.Label();
            this.totalValueDivine = new Terminal.Gui.Label();
            this.totalValuechaos = new Terminal.Gui.Label();
            this.lastMapsBorder2 = new Terminal.Gui.FrameView();
            this.mapList = new Terminal.Gui.ListView();
            this.lastMapsBorder = new Terminal.Gui.FrameView();
            this.tabView = new Terminal.Gui.TabView();
            this.greenOnBlack = new Terminal.Gui.ColorScheme();
            this.greenOnBlack.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Black);
            this.greenOnBlack.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Black);
            this.greenOnBlack.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Green, Terminal.Gui.Color.Magenta);
            this.greenOnBlack.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightGreen, Terminal.Gui.Color.Magenta);
            this.greenOnBlack.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black);
            this.blueOnBlack = new Terminal.Gui.ColorScheme();
            this.blueOnBlack.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightBlue, Terminal.Gui.Color.Black);
            this.blueOnBlack.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Cyan, Terminal.Gui.Color.Black);
            this.blueOnBlack.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightBlue, Terminal.Gui.Color.BrightYellow);
            this.blueOnBlack.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Cyan, Terminal.Gui.Color.BrightYellow);
            this.blueOnBlack.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black);
            this.redOnBlack = new Terminal.Gui.ColorScheme();
            this.redOnBlack.Normal = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Black);
            this.redOnBlack.HotNormal = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightRed, Terminal.Gui.Color.Black);
            this.redOnBlack.Focus = new Terminal.Gui.Attribute(Terminal.Gui.Color.Red, Terminal.Gui.Color.Brown);
            this.redOnBlack.HotFocus = new Terminal.Gui.Attribute(Terminal.Gui.Color.BrightRed, Terminal.Gui.Color.Brown);
            this.redOnBlack.Disabled = new Terminal.Gui.Attribute(Terminal.Gui.Color.Gray, Terminal.Gui.Color.Black);
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
            this.tabView.Width = 117;
            this.tabView.Height = 27;
            this.tabView.X = 0;
            this.tabView.Y = 0;
            this.tabView.Data = "tabView";
            this.tabView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.tabView.MaxTabTextWidth = 30u;
            this.tabView.Style.ShowBorder = true;
            this.tabView.Style.ShowTopLine = true;
            this.tabView.Style.TabsOnBottom = false;
            Terminal.Gui.TabView.Tab tabViewoverview;
            tabViewoverview = new Terminal.Gui.TabView.Tab("Overview", new View());
            tabViewoverview.View.Width = Dim.Fill();
            tabViewoverview.View.Height = Dim.Fill();
            this.lastMapsBorder.Width = 51;
            this.lastMapsBorder.Height = 22;
            this.lastMapsBorder.X = 1;
            this.lastMapsBorder.Y = 0;
            this.lastMapsBorder.Data = "lastMapsBorder";
            this.lastMapsBorder.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.lastMapsBorder.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.lastMapsBorder.Border.Effect3D = false;
            this.lastMapsBorder.Border.Effect3DBrush = null;
            this.lastMapsBorder.Border.DrawMarginFrame = true;
            this.lastMapsBorder.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder.Title = "Maps";
            tabViewoverview.View.Add(this.lastMapsBorder);
            this.mapList.Width = 72;
            this.mapList.Height = 23;
            this.mapList.X = 2;
            this.mapList.Y = 1;
            this.mapList.Data = "mapList";
            this.mapList.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.mapList.Source = new Terminal.Gui.ListWrapper(new string[] {
                        "-"});
            this.lastMapsBorder.Add(this.mapList);
            this.lastMapsBorder2.Width = 61;
            this.lastMapsBorder2.Height = 23;
            this.lastMapsBorder2.X = 53;
            this.lastMapsBorder2.Y = 0;
            this.lastMapsBorder2.Data = "lastMapsBorder2";
            this.lastMapsBorder2.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.lastMapsBorder2.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.lastMapsBorder2.Border.Effect3D = false;
            this.lastMapsBorder2.Border.Effect3DBrush = null;
            this.lastMapsBorder2.Border.DrawMarginFrame = true;
            this.lastMapsBorder2.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder2.Title = "Inventory";
            tabViewoverview.View.Add(this.lastMapsBorder2);
            this.totalValuechaos.Width = 4;
            this.totalValuechaos.Height = 1;
            this.totalValuechaos.X = 2;
            this.totalValuechaos.Y = 1;
            this.totalValuechaos.Data = "totalValuechaos";
            this.totalValuechaos.Text = "Total value (chaos): -";
            this.totalValuechaos.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder2.Add(this.totalValuechaos);
            this.totalValueDivine.Width = 4;
            this.totalValueDivine.Height = 1;
            this.totalValueDivine.X = 2;
            this.totalValueDivine.Y = 2;
            this.totalValueDivine.Data = "totalValueDivine";
            this.totalValueDivine.Text = "Total value (divine): -";
            this.totalValueDivine.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder2.Add(this.totalValueDivine);
            this.timeInMapInventory.Width = 4;
            this.timeInMapInventory.Height = 1;
            this.timeInMapInventory.X = 2;
            this.timeInMapInventory.Y = 4;
            this.timeInMapInventory.Data = "timeInMapInventory";
            this.timeInMapInventory.Text = "Time spent in map:";
            this.timeInMapInventory.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder2.Add(this.timeInMapInventory);
            this.chaosPerHourInventory.Width = 4;
            this.chaosPerHourInventory.Height = 1;
            this.chaosPerHourInventory.X = 35;
            this.chaosPerHourInventory.Y = 4;
            this.chaosPerHourInventory.Data = "chaosPerHourInventory";
            this.chaosPerHourInventory.Text = "(c) / h: ";
            this.chaosPerHourInventory.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.lastMapsBorder2.Add(this.chaosPerHourInventory);
            this.tableView.Width = 57;
            this.tableView.Height = 16;
            this.tableView.X = 1;
            this.tableView.Y = 5;
            this.tableView.Data = "tableView";
            this.tableView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.tableView.FullRowSelect = false;
            this.tableView.Style.AlwaysShowHeaders = false;
            this.tableView.Style.ExpandLastColumn = true;
            this.tableView.Style.InvertSelectedCellFirstCharacter = false;
            this.tableView.Style.ShowHorizontalHeaderOverline = true;
            this.tableView.Style.ShowHorizontalHeaderUnderline = true;
            this.tableView.Style.ShowVerticalCellLines = true;
            this.tableView.Style.ShowVerticalHeaderLines = true;
            System.Data.DataTable tableViewTable;
            tableViewTable = new System.Data.DataTable();
            System.Data.DataColumn tableViewTableColumn0;
            tableViewTableColumn0 = new System.Data.DataColumn();
            tableViewTableColumn0.ColumnName = "Column 0";
            tableViewTable.Columns.Add(tableViewTableColumn0);
            System.Data.DataColumn tableViewTableColumn1;
            tableViewTableColumn1 = new System.Data.DataColumn();
            tableViewTableColumn1.ColumnName = "Column 1";
            tableViewTable.Columns.Add(tableViewTableColumn1);
            System.Data.DataColumn tableViewTableColumn2;
            tableViewTableColumn2 = new System.Data.DataColumn();
            tableViewTableColumn2.ColumnName = "Column 2";
            tableViewTable.Columns.Add(tableViewTableColumn2);
            System.Data.DataColumn tableViewTableColumn3;
            tableViewTableColumn3 = new System.Data.DataColumn();
            tableViewTableColumn3.ColumnName = "Column 3";
            tableViewTable.Columns.Add(tableViewTableColumn3);
            this.tableView.Table = tableViewTable;
            this.lastMapsBorder2.Add(this.tableView);
            this.deleteMap.Width = 23;
            this.deleteMap.Height = 1;
            this.deleteMap.X = 2;
            this.deleteMap.Y = 22;
            this.deleteMap.Data = "deleteMap";
            this.deleteMap.Text = "Delete selected map";
            this.deleteMap.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.deleteMap.IsDefault = false;
            tabViewoverview.View.Add(this.deleteMap);
            tabView.AddTab(tabViewoverview, false);
            Terminal.Gui.TabView.Tab tabViewstatistics;
            tabViewstatistics = new Terminal.Gui.TabView.Tab("Statistics", new View());
            tabViewstatistics.View.Width = Dim.Fill();
            tabViewstatistics.View.Height = Dim.Fill();
            this.statisticsFrame.Width = 34;
            this.statisticsFrame.Height = 23;
            this.statisticsFrame.X = 80;
            this.statisticsFrame.Y = 0;
            this.statisticsFrame.Data = "statisticsFrame";
            this.statisticsFrame.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.statisticsFrame.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.statisticsFrame.Border.Effect3D = false;
            this.statisticsFrame.Border.Effect3DBrush = null;
            this.statisticsFrame.Border.DrawMarginFrame = true;
            this.statisticsFrame.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.statisticsFrame.Title = "Tracker";
            tabViewstatistics.View.Add(this.statisticsFrame);
            this.frameView.Width = 32;
            this.frameView.Height = 6;
            this.frameView.X = 0;
            this.frameView.Y = 0;
            this.frameView.Data = "frameView";
            this.frameView.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.frameView.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.frameView.Border.Effect3D = false;
            this.frameView.Border.Effect3DBrush = null;
            this.frameView.Border.DrawMarginFrame = true;
            this.frameView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Title = "Last Map Info";
            this.statisticsFrame.Add(this.frameView);
            this.timeInMapStatistic.Width = 6;
            this.timeInMapStatistic.Height = 1;
            this.timeInMapStatistic.X = 1;
            this.timeInMapStatistic.Y = 0;
            this.timeInMapStatistic.Data = "timeInMapStatistic";
            this.timeInMapStatistic.Text = "Time:";
            this.timeInMapStatistic.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Add(this.timeInMapStatistic);
            this.lastMapValueStatistic.Width = 4;
            this.lastMapValueStatistic.Height = 1;
            this.lastMapValueStatistic.X = 1;
            this.lastMapValueStatistic.Y = 1;
            this.lastMapValueStatistic.Data = "lastMapValueStatistic";
            this.lastMapValueStatistic.Text = "Value (c): ";
            this.lastMapValueStatistic.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Add(this.lastMapValueStatistic);
            this.chaosPerHourStatistic.Width = 7;
            this.chaosPerHourStatistic.Height = 1;
            this.chaosPerHourStatistic.X = 1;
            this.chaosPerHourStatistic.Y = 2;
            this.chaosPerHourStatistic.Data = "chaosPerHourStatistic";
            this.chaosPerHourStatistic.Text = "(c) / h:";
            this.chaosPerHourStatistic.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Add(this.chaosPerHourStatistic);
            this.divinePerHourStatistic.Width = 7;
            this.divinePerHourStatistic.Height = 1;
            this.divinePerHourStatistic.X = 1;
            this.divinePerHourStatistic.Y = 3;
            this.divinePerHourStatistic.Data = "divinePerHourStatistic";
            this.divinePerHourStatistic.Text = "(d) / h:";
            this.divinePerHourStatistic.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView.Add(this.divinePerHourStatistic);
            this.frameView2.Width = 32;
            this.frameView2.Height = 6;
            this.frameView2.X = 0;
            this.frameView2.Y = 6;
            this.frameView2.Data = "frameView2";
            this.frameView2.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.frameView2.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.frameView2.Border.Effect3D = false;
            this.frameView2.Border.Effect3DBrush = null;
            this.frameView2.Border.DrawMarginFrame = true;
            this.frameView2.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView2.Title = "General Map Info";
            this.statisticsFrame.Add(this.frameView2);
            this.averageTimePerMap.Width = 11;
            this.averageTimePerMap.Height = 1;
            this.averageTimePerMap.X = 1;
            this.averageTimePerMap.Y = 0;
            this.averageTimePerMap.Data = "averageTimePerMap";
            this.averageTimePerMap.Text = "Avg time / map:";
            this.averageTimePerMap.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView2.Add(this.averageTimePerMap);
            this.averageValuePerMap.Width = 4;
            this.averageValuePerMap.Height = 1;
            this.averageValuePerMap.X = 1;
            this.averageValuePerMap.Y = 1;
            this.averageValuePerMap.Data = "averageStatistic";
            this.averageValuePerMap.Text = "Avg value (c): ";
            this.averageValuePerMap.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView2.Add(this.averageValuePerMap);
            this.averageChaosPerHour.Width = 11;
            this.averageChaosPerHour.Height = 1;
            this.averageChaosPerHour.X = 1;
            this.averageChaosPerHour.Y = 2;
            this.averageChaosPerHour.Data = "realChaosPerHour";
            this.averageChaosPerHour.Text = "Avg (c) / h:";
            this.averageChaosPerHour.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView2.Add(this.averageChaosPerHour);
            this.averageDivinePerHour.Width = 8;
            this.averageDivinePerHour.Height = 1;
            this.averageDivinePerHour.X = 1;
            this.averageDivinePerHour.Y = 3;
            this.averageDivinePerHour.Data = "realDivinePerHour";
            this.averageDivinePerHour.Text = "Avg (d) / h:";
            this.averageDivinePerHour.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView2.Add(this.averageDivinePerHour);
            this.frameView3.Width = 32;
            this.frameView3.Height = 9;
            this.frameView3.X = 0;
            this.frameView3.Y = 12;
            this.frameView3.Data = "frameView3";
            this.frameView3.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.frameView3.Border.BorderBrush = Terminal.Gui.Color.Black;
            this.frameView3.Border.Effect3D = false;
            this.frameView3.Border.Effect3DBrush = null;
            this.frameView3.Border.DrawMarginFrame = true;
            this.frameView3.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Title = "Real-time tracker";
            this.statisticsFrame.Add(this.frameView3);
            this.trackerTotalTime.Width = 5;
            this.trackerTotalTime.Height = 1;
            this.trackerTotalTime.X = 1;
            this.trackerTotalTime.Y = 0;
            this.trackerTotalTime.Data = "trackerTotalTime";
            this.trackerTotalTime.Text = "Total time:";
            this.trackerTotalTime.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Add(this.trackerTotalTime);
            this.trackerAvgTimePerMap.Width = 5;
            this.trackerAvgTimePerMap.Height = 1;
            this.trackerAvgTimePerMap.X = 1;
            this.trackerAvgTimePerMap.Y = 1;
            this.trackerAvgTimePerMap.Data = "trackerAvgTimePerMap";
            this.trackerAvgTimePerMap.Text = "Avg time / map:";
            this.trackerAvgTimePerMap.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Add(this.trackerAvgTimePerMap);
            this.trackerAvgChaosPerMap.Width = 5;
            this.trackerAvgChaosPerMap.Height = 1;
            this.trackerAvgChaosPerMap.X = 1;
            this.trackerAvgChaosPerMap.Y = 2;
            this.trackerAvgChaosPerMap.Data = "trackerAvgChaosPerMap";
            this.trackerAvgChaosPerMap.Text = "Avg value (c):";
            this.trackerAvgChaosPerMap.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Add(this.trackerAvgChaosPerMap);
            this.trackerChaosPerHour.Width = 8;
            this.trackerChaosPerHour.Height = 1;
            this.trackerChaosPerHour.X = 1;
            this.trackerChaosPerHour.Y = 3;
            this.trackerChaosPerHour.Data = "trackerChaosPerHour";
            this.trackerChaosPerHour.Text = "(c) / h:";
            this.trackerChaosPerHour.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Add(this.trackerChaosPerHour);
            this.trackerDivinePerHour.Width = 8;
            this.trackerDivinePerHour.Height = 1;
            this.trackerDivinePerHour.X = 1;
            this.trackerDivinePerHour.Y = 4;
            this.trackerDivinePerHour.Data = "trackerDivinePerHour";
            this.trackerDivinePerHour.Text = "(d) / h:";
            this.trackerDivinePerHour.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.frameView3.Add(this.trackerDivinePerHour);
            this.startButton.Width = 1;
            this.startButton.Height = 1;
            this.startButton.X = 1;
            this.startButton.Y = 6;
            this.startButton.ColorScheme = this.redOnBlack;
            this.startButton.Data = "startButton";
            this.startButton.Text = "Start";
            this.startButton.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.startButton.IsDefault = false;
            this.frameView3.Add(this.startButton);
            this.stopButton.Width = 8;
            this.stopButton.Height = 1;
            this.stopButton.X = 11;
            this.stopButton.Y = 6;
            this.stopButton.ColorScheme = this.redOnBlack;
            this.stopButton.Data = "stopButton";
            this.stopButton.Text = "Stop";
            this.stopButton.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.stopButton.IsDefault = false;
            this.frameView3.Add(this.stopButton);
            this.resetButton.Width = 9;
            this.resetButton.Height = 1;
            this.resetButton.X = 20;
            this.resetButton.Y = 6;
            this.resetButton.ColorScheme = this.redOnBlack;
            this.resetButton.Data = "resetButton";
            this.resetButton.Text = "Reset";
            this.resetButton.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.resetButton.IsDefault = false;
            this.frameView3.Add(this.resetButton);
            this.graphView.Width = 78;
            this.graphView.Height = 22;
            this.graphView.X = 1;
            this.graphView.Y = 1;
            this.graphView.ColorScheme = this.blueOnBlack;
            this.graphView.Data = "graphView";
            this.graphView.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.graphView.GraphColor = Terminal.Gui.Attribute.Make(Color.White, Color.Black);
            this.graphView.ScrollOffset = new Terminal.Gui.PointF(0F, 0F);
            this.graphView.MarginLeft = 4u;
            this.graphView.MarginBottom = 2u;
            this.graphView.CellSize = new Terminal.Gui.PointF(1F, 1F);
            this.graphView.AxisX.Visible = true;
            this.graphView.AxisX.Increment = 1F;
            this.graphView.AxisX.ShowLabelsEvery = 5u;
            this.graphView.AxisX.Minimum = null;
            this.graphView.AxisX.Text = "Maps";
            this.graphView.AxisY.Visible = true;
            this.graphView.AxisY.Increment = 1F;
            this.graphView.AxisY.ShowLabelsEvery = 5u;
            this.graphView.AxisY.Minimum = null;
            this.graphView.AxisY.Text = "Chaos";
            tabViewstatistics.View.Add(this.graphView);
            tabView.AddTab(tabViewstatistics, false);
            this.tabView.ApplyStyleChanges();
            this.Add(this.tabView);
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