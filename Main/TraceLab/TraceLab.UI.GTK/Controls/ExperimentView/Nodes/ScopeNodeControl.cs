                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 // TraceLab - Software Traceability Instrument to Facilitate and Empower Traceability Research
// Copyright (C) 2012-2013 CoEST - National Science Foundation MRI-R2 Grant # CNS: 0959924
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see<http://www.gnu.org/licenses/>.
//

// HERZUM SPRINT 0.0 CLASS
//

using System;
using TraceLab.Core.Experiments;
using MonoHotDraw.Handles;
using System.Collections.Generic;
using MonoHotDraw.Util;

using Cairo;
using MonoHotDraw;
using MonoHotDraw.Connectors;
using MonoHotDraw.Tools;
using MonoHotDraw.Figures;

// HERZUM SPRINT 1.0
using Gdk;
using Gtk;
using TraceLab.Core.Components;
using MonoDevelop.Components.Docking;

// END HERZUM 0.0

using MonoHotDraw.Locators;

namespace TraceLab.UI.GTK
{
    // HERZUM SPRINT 1.2 TLAB-52 - ComponentControl --> ComponentResizeControl
    public class ScopeNodeControl : ComponentResizeControl
    {
        // HERZUM SPRINT 1.1 MAX
     
        Boolean firstDrawScope=true;

        //HERZUM SPRINT 2.0 TLAB-135
        private Boolean iconisationForced=false;

        public Boolean IconisationForced
        {
            get { return iconisationForced; }
            set 
            {              
                iconisationForced = value;
            }
         }

        public override void BasicDrawSelected (Cairo.Context context)
        {
            base.BasicDrawSelected (context);
            if (IconisationForced)
            { 
                NormalizeScope ();
                IconisationForced = false;
            } 

            OverlayScope (m_applicationContext);
        }

        //END HERZUM SPRINT 2.0 TLAB-135

        public ScopeNodeControl(ExperimentNode node, ApplicationContext applicationContext) 
            : base(node, applicationContext)
        {
        }

        //END HERZUM SPRINT 1.1 MAX

        // HERZUM SPRINT 1.0

        //HERZUM SPRINT 2.0 TLAB-135
        //private double xCur;
        //private double yCur;
        //HERZUM SPRINT 2.0 TLAB-135

        //HERZUM SPRINT 2.0 TLAB-136
        //private ScopeCanvasPad scopeCanvasPad = null;
        private ExperimentCanvasPad scopeCanvasPad = null;
        //END HERZUM SPRINT 2.0 TLAB-136

        // HERZUM SPRINT 1.1 LOOP
        // private ExperimentCanvasWidget m_scopeCanvasWidget = null;
        protected ExperimentCanvasWidget m_scopeCanvasWidget = null;
        // END HERZUM SPRINT 1.1 LOOP

        private Boolean nodeCreated = false;
        // END HERZUM 1.0 

        // HERZUM SPRINT 1.2 TLAB 41
        protected virtual bool IsOnlyScope()
        {
            //HERZUM SPRINT 2.0 TLAB-153
            // System.Collections.IEnumerator edges = this.m_applicationContext.Application.Experiment.OutEdges (((ScopeNode)this.ExperimentNode).DecisionNode).GetEnumerator();
            System.Collections.IEnumerator edges = ExperimentNode.Owner.OutEdges (((ScopeNode)this.ExperimentNode).DecisionNode).GetEnumerator();
            //END HERZUM SPRINT 2.0 TLAB-153
            int n = 0;
            while (edges.MoveNext())
                n++;
            return n == 2;
        }
        // END HERZUM SPRINT 1.2 TLAB 41

        //HERZUM SPRINT 1.1 MAX
        public override IEnumerable<IHandle> HandlesEnumerator 
        {
            get 
            {
                foreach (IHandle handle in base.HandlesEnumerator) 
                {
                    // HERZUM SPRINT 1.2 TLAB 41 
                    // if (!(IsDecisionScope() && handle is NewConnectionHandle))
                    bool cond1 = IsDecisionScope () && handle is NewConnectionHandle;
                    bool cond2 = IsDecisionScope () && IsOnlyScope () && handle is RemoveNodeHandle;
                    if (!(cond1 || cond2))
                    // END HERZUM SPRINT 1.2 TLAB 41.2 TLAB 41
                        yield return handle;
                }
             
                if (stateWidget=="normal")
                {
                    yield return m_maxScope;
                    yield return m_minScope;
                    yield return m_resizeScope_NorthEast;
                    yield return m_resizeScope_SouthEast;
                    yield return m_resizeScope_SouthWest;
                    yield return m_resizeScope_NorthWest;
                }
                else if (stateWidget=="max")
                {
                    yield return m_minScope;
                    yield return m_normalScope;
                }
                else if (stateWidget=="iconized")
                {
                    yield return m_normalScope;
                    yield return m_maxScope;
                }
            }
        }
        //END HERZUM SPRINT 1.1 MAX

        public ExperimentCanvasWidget ScopeCanvasWidget
        {
            get { return m_scopeCanvasWidget; }
        }

        // HERZUM SPRINT 1.1 IF
        // HERZUM SPRINT 1.2 IF - add virtual
        protected virtual bool IsDecisionScope()
        {
            return ((ScopeNode)ExperimentNode).DecisionNode != null;
        }
        // END HERZUM SPRINT 1.2 IF
        // END HERZUM SPRINT 1.1Y IF



        // HERZUM SPRINT 1.1 FOCUS
        // bool found = false;
        public override bool IsSelected {
            get {
                return base.IsSelected;
            }
            set {
                if (value && !base.IsSelected){
                    // HERZUM SPRINT 2.4: TLAB-156
                    // HERZUM SPRINT 5.3 TLAB-185
                    //ecp.RedrawScope (m_scopeCanvasWidget,  rect.X+1+offsetPanX, rect2.Y2+1+offsetPanY, rect.Width -10, rect.Height - rect2.Height -10);
                    ecp.RedrawScope (m_scopeCanvasWidget,  rect.X+edgeBorder+offsetPanX, rect2.Y2+edgeBorder+offsetPanY);
                    // END HERZUM SPRINT 5.3 TLAB-185
                    // END HERZUM SPRINT 2.4: TLAB-156
                    /*
                    if (!found){
                        found = true;
                        var metadata = this.ExperimentNode.Data.Metadata;
                        ScopeBaseMetadata scopeMetadata = metadata as ScopeBaseMetadata;
                        m_applicationContext.MainWindow.ExperimentCanvasPad.PaintScope (scopeMetadata.ComponentGraph);
                    }
                    */
                }
                // END HERZUM SPRINT 1.1 CANVAS

                //update also corresponding value in model experiment node
                base.IsSelected = value;
            }

        }


        /*
        public override void BasicDrawSelected (Cairo.Context context)
        {
            base.BasicDrawSelected(context);
            if (this.IsSelected)
                m_applicationContext.MainWindow.ExperimentCanvasPad.RedrawScope (m_scopeCanvasWidget,  rect.X +10, rect2.Y2 + 10, rect.Width -10, rect.Height - rect2.Height -10);
        }
        */

        // END HERZUM SPRINT 1.1 FOCUS

        // HERZUM SPRINT 1.0 MAX
        public void ResizeScope(double widthMax, double heightMax) {
            m_scopeCanvasWidget.SetSizeRequest ((int)widthMax, (int)heightMax);
        }
        // END HERZUM SPRINT 1.0 MAX


        // HERZUM SPRINT 1.2 TLAB-133
        protected override void  ResizeCanvasWidget() {
            // HERZUM SPRINT 5.3 TLAB-185
            //m_scopeCanvasWidget.WidthRequest = (int)(rect.X2 - rect.X) - (int)(Math.Round(3.0/valueZoom));
            //m_scopeCanvasWidget.HeightRequest = (int)(rect.Y2 - rect2.Y2) - (int)(Math.Round(3.0/valueZoom));
            m_scopeCanvasWidget.WidthRequest = (int)(rect.X2 - rect.X) -  (int)(Math.Round(8.0*valueZoom));
            m_scopeCanvasWidget.HeightRequest = (int)(rect.Y2 - rect2.Y2) - (int)(Math.Round(8.0*valueZoom));
            // END HERZUM SPRINT 5.3 TLAB-185
        }
        // END HERZUM SPRINT 1.2 TLAB-133


        
        protected override void GetPointer(out int xMouse, out int yMouse){
            m_scopeCanvasWidget.GetPointer(out xMouse, out yMouse);
            //HERZUM SPRINT 2: TLAB-156
            xMouse = (int)((xMouse)/valueZoom);
            yMouse = (int)((yMouse)/valueZoom);
            //HERZUM END SPRINT 2: TLAB-156
        }


        protected override void ShowWidget(){ 
            m_scopeCanvasWidget.Show ();
        }

        protected override void HideWidget(){ 
            m_scopeCanvasWidget.Hide ();
        }


        protected override void DrawFrame (Cairo.Context context, double lineWidth, Cairo.Color lineColor, Cairo.Color fillColor)
        {          
            rect = DisplayBox;
            rect.OffsetDot5();
            CairoFigures.AngleFrame(context, rect, 0, 0, 0, 0);

            Cairo.Color fillColorOrigin;
            fillColorOrigin = fillColor;

            lineWidth = 1;
            fillColor = new Cairo.Color (1.0, 1.0, 1.0, 1.0);

            context.Color = fillColor;  
            context.FillPreserve();
            context.Color = lineColor;
            context.LineWidth = lineWidth;

            double[] dash = {2, 0, 2};
            context.SetDash (dash, 0);

            context.Stroke();

            rect2 = DisplayBox;
            rect2.Width = DisplayBox.Width;
            rect2.Height = 30;
            rect2.OffsetDot5();
            CairoFigures.AngleFrame(context, rect2, 0, 0, 0, 0);
            fillColor = fillColorOrigin;
            context.Color = fillColor;  
            context.FillPreserve();
            context.Color = lineColor;
            context.LineWidth = lineWidth;

            context.Stroke();

            // HERZUM SPRINT 1.1 LOOP 
            DrawScope ();
            // END HERZUM SPRINT 1.1 LOOP

        }


        //HERZUM SPRINT 2.0 TLAB-136
        ExperimentCanvasPad ecp=null; 
        //END HERZUM SPRINT 2.0 TLAB-136

        // HERZUM SPRINT 5.0: TLAB-235
        protected void DrawScope (){
            DrawScope ("Start", "End");
        }
        // END HERZUM SPRINT 5.0: TLAB-235

        // HERZUM SPRINT 1.1 LOOP
        protected void DrawScope (String start, String end){

            var metadata = this.ExperimentNode.Data.Metadata;
            ScopeBaseMetadata scopeMetadata = metadata as ScopeBaseMetadata;

            //componentGraph might be null if component metadata definition is not existing in the library 
            if(scopeMetadata.ComponentGraph != null)
            {
                // HERZUM SPRINT 1.1 CANVAS
                // return;
                // END HERZUM SPRINT 1.1 CANVAS

                if (m_scopeCanvasWidget == null)
                {
                    // HERZUM SPRINT 1.0
                    //scopeCanvasPad = new ExperimentCanvasPad(m_applicationContext);
                    //scopeCanvasPad = new  ScopeCanvasPad(m_applicationContext);
                    // END HERZUM SPRINT 1.0

                    //HERZUM SPRINT 2.0 TLAB-136
                    scopeCanvasPad = ExperimentCanvasPadFactory.CreateExperimentCanvasPad (m_applicationContext,this);
                    //END HERZUM SPRINT 2.0 TLAB-136

                    DockFrame m_dockFrame = new DockFrame();
                    Gdk.WindowAttr attributes = new Gdk.WindowAttr();
                    attributes.WindowType = Gdk.WindowType.Child;

                    attributes.X = 100;
                    attributes.Y = 100;
                    attributes.Width = 100;
                    attributes.Height = 100;    

                    Gdk.WindowAttributesType mask = WindowAttributesType.X | WindowAttributesType.Y;
                    m_dockFrame.GdkWindow = new Gdk.Window(null, attributes, (int) mask);
                    scopeCanvasPad.Initialize (m_dockFrame);

                    
                    // HERZUM SPRINT 2.2 TLAB-101 TLAB-102
                    foreach (ExperimentNode node in scopeMetadata.ComponentGraph.GetExperiment().Vertices)
                    {
                        if (node is ExperimentStartNode)
                            // HERZUM SPRINT 5.0: TLAB-235
                            // node.Data.Metadata.Label = "Start";
                            node.Data.Metadata.Label = start;
                        // END HERZUM SPRINT 5.0: TLAB-235

                        if (node is ExperimentEndNode)
                        {
                            // HERZUM SPRINT 5.0: TLAB-235
                            // node.Data.Metadata.Label = "End";
                            node.Data.Metadata.Label = end;
                            // END HERZUM SPRINT 5.0: TLAB-235

                            //HERZUM SPRINT 2.4 TLAB-158
                            // HERZUM SPRINT 5.0: TLAB-235
                            if (scopeMetadata.ComponentGraph.GetExperiment().StartNode.Data.X == 0 && 
                                scopeMetadata.ComponentGraph.GetExperiment().StartNode.Data.Y == 0 &&
                                scopeMetadata.ComponentGraph.GetExperiment().EndNode.Data.X == 0 && 
                                scopeMetadata.ComponentGraph.GetExperiment().EndNode.Data.Y == 0)
                            // END HERZUM SPRINT 5.0: TLAB-235
                                //HERZUM SPRINT 5.3 TLAB-185
                                    node.Data.Y =+ 110;
                               //END HERZUM SPRINT 5.3 TLAB-185
                            //END HERZUM SPRINT 2.4 TLAB-158
                        }
                    }
                    // END HERZUM SPRINT 2.2 TLAB-101 TLAB-102

                    // HERZUM SPRINT 1.0
                    scopeCanvasPad.SetScopeApplicationModel(this, m_applicationContext.Application, scopeMetadata.ComponentGraph);
                    // scopeCanvasPad.SetScopeApplicationModel(m_applicationContext.Application, scopeMetadata.ComponentGraph);
                    // END HERZUM SPRINT 1.0


                    // HERZUM SPRINT 1.0
                    //m_scopeCanvasWidget = scopeCanvasPad.ScopeCanvasWidget;
                    m_scopeCanvasWidget = scopeCanvasPad.ExperimentCanvasWidget;
                    m_scopeCanvasWidget.DestroyVbox1();
                    // END HERZUM SPRINT 1.0

                }

                // HERZUM SPRINT 2.1
                // m_applicationContext.MainWindow.ExperimentCanvasPad.ScopeNodeControlCurrent = this;
                // END HERZUM SPRINT 2.1


                
                //HERZUM SPRINT 2.0 TLAB-136
                ecp = ExperimentCanvasPadFactory.GetExperimentCanvasPad (m_applicationContext, this);
                //END HERZUM SPRINT 2.0 TLAB-136

                valueZoom = ecp.ExperimentCanvasWidget.ExperimentCanvas.View.Scale;

                if (!nodeCreated)
                {

                    xCur=rect.X;
                    yCur=rect.Y;

                    //PRINT 1.2 TLAB-133
                    //HERZUM SPRINT 2.0 TLAB-136
                    // HERZUM SPRINT 2.4: TLAB-156
                    offsetPanX =  ecp.ExperimentCanvasWidget.OffsetPanX;
                    offsetPanY= ecp.ExperimentCanvasWidget.OffsetPanY;

                    // HERZUM SPRINT 5.3: TLAB-185
                    //ecp.DisplayScope (m_scopeCanvasWidget, rect.X+1+offsetPanX, rect2.Y2+1+offsetPanY); 
                    //ecp.DisplayScope (m_scopeCanvasWidget, rect.X+edgeBorder+offsetPanX, rect2.Y2+edgeBorder+offsetPanY); 
                    ecp.DisplayScope (m_scopeCanvasWidget, (int)((rect.X+edgeBorder+offsetPanX)*valueZoom), (int)((rect2.Y2+edgeBorder+offsetPanY)*valueZoom)); 
                    // END HERZUM SPRINT 5.3: TLAB-185

                    // END HERZUM SPRINT 2.4: TLAB-156
                    //END HERZUM SPRINT 2.0 TLAB-136
                    //END HERZUM SPRINT 1.2 TLAB-133

                    m_scopeCanvasWidget.Show();
                    nodeCreated=true;
                } 

                else if (xCur!=rect.X  ||  yCur!=rect.Y) 
                { 
                    //HERZUM SPRINT 1.2 TLAB-133
                    //HERZUM SPRINT 2.0 TLAB-136

                    //HERZUM SPRINT 2: TLAB-156
                    if (valueZoom==zoomPrevious && valueZoom==1)
                        // HERZUM SPRINT 2.4: TLAB-156
                        // HERZUM SPRINT 5.3: TLAB-185
                        //ecp.MoveScope (m_scopeCanvasWidget, rect.X+1+offsetPanX, rect2.Y2+1+offsetPanY);
                        ecp.MoveScope (m_scopeCanvasWidget, rect.X+edgeBorder+offsetPanX, rect2.Y2+edgeBorder+offsetPanY);
                        // END HERZUM SPRINT 5.3: TLAB-185
                        // END HERZUM SPRINT 2.4: TLAB-156
                    //END HERZUM SPRINT 2: TLAB-156

                    //END HERZUM SPRINT 2.0 TLAB-136

                    xCur=rect.X;
                    yCur=rect.Y;

                    //HERZUM SPRINT 2.0 TLAB-135
                    if (IconisationForced)
                    { 
                        NormalizeScope ();
                        IconisationForced = false;
                    } 

                    OverlayScope (m_applicationContext);
                    //END HERZUM SPRINT 2.0 TLAB-135

                } 


                //HERZUM SPRINT 1.2 TLAB-133
                ResizeCanvasWidget ();
                //END HERZUM SPRINT 1.2 TLAB-133

            }

            if (firstDrawScope)
                if (stateWidget=="max")
                { 
                    MaximizeScope();
                    PaddingBottom = PaddingBottom - 20;
                }
                else if (stateWidget=="iconized")
                    IconizeScope();

            if (stateWidget=="iconized")
                m_scopeCanvasWidget.Hide();

            //HERZUM SPRINT 2.0 TLAB-135
            if (firstDrawScope)
            { 
                OverlayScope (m_applicationContext);
                firstDrawScope=false;
            }
            //END HERZUM SPRINT 2.0 TLAB-135


            //HERZUM SPRINT 2.0 TLAB-135
            if (IsResize)
            { 
                OverlayScope (m_applicationContext);
                IsResize=false;
            }
            //END HERZUM SPRINT 2.0 TLAB-135   


            //HERZUM SPRINT 2: TLAB-156
            valueZoom = ecp.ExperimentCanvasWidget.ExperimentCanvas.View.Scale;
            m_scopeCanvasWidget.ExperimentCanvas.View.Scale = valueZoom;   
            SetZoom (valueZoom);
            //HERZUM END SPRINT 2: TLAB-156

            
            // HERZUM SPRINT 2.4: TLAB-156
            //HERZUM SPRINT 5.5 TLAB-216
            point = ecp.ExperimentCanvasWidget.ExperimentCanvas.View.DrawingToView ((int)rect.X / valueZoom, (int)rect2.Y2 / valueZoom);
            offsetPanX = (point.X - rect.X) / valueZoom;
            offsetPanY = (point.Y - rect2.Y - 30) / valueZoom;
            //END HERZUM SPRINT 5.5 TLAB-216 
            if (ecp.ExperimentCanvasWidget.IsPanToolButtonActive ()) {
                //point = ecp.ExperimentCanvasWidget.ExperimentCanvas.View.DrawingToView ((int)rect.X / valueZoom, (int)rect2.Y2 / valueZoom);
                //offsetPanX = (point.X - rect.X) / valueZoom;
                //offsetPanY = (point.Y - rect2.Y - 30) / valueZoom;
                if (valueZoom == 1)
                    // HERZUM SPRINT 5.3: TLAB-185
                    //ecp.MoveScope (m_scopeCanvasWidget, point.X + 1, point.Y);
                    ecp.MoveScope (m_scopeCanvasWidget, point.X + edgeBorder, point.Y + edgeBorder);              
                   // END HERZUM SPRINT 5.3: TLAB-185
            } 
            // END HERZUM SPRINT 2.4: TLAB-156
              

        }
        // END HERZUM SPRINT 1.1 LOOP

        /// <summary>
        /// Determines the default x location of Any/All button 
        /// </summary>
        private static double s_waitForAnyAllHandleXLocation = 25;

        /// <summary>
        /// Determines the default x location of Any/All button 
        /// </summary>
        private static double s_waitForAnyAllHandleYLocation = 14.9;

        // HERZUM SPRINT 1.0
        // HERZUM SPRINT 1.0 CANVAS da commentare la routine
        public override void CompositeComponentNoSelected(BasicNodeControl focusControl)  {

            base.CompositeComponentNoSelected (focusControl);
            var metadata = this.ExperimentNode.Data.Metadata;
            ScopeBaseMetadata scopeMetadata = metadata as ScopeBaseMetadata;          
            if(scopeMetadata.ComponentGraph != null)
            {
                BasicNodeControl componentControl;
                foreach (ExperimentNode node in scopeMetadata.ComponentGraph.Vertices)
                    if (m_applicationContext.NodeControlFactory.TryGetNodeControl (node, out componentControl)){
                        // HERZUM SPRINT 2.0 TLAB-136-2
                        // if (!componentControl.Equals(focusControl)){                            
                            // m_scopeCanvasWidget.ExperimentCanvas.View.RemoveFromSelection(componentControl);
                        componentControl.CompositeComponentNoSelected (focusControl);                            
                        // }
                    // END HERZUM SPRINT 2.0 TLAB-136-2TLAB-136-2
                        
                     }
             }

         }
        // END HERZUM SPRINT 1.0



        //HERZUM SPRINT 2: TLAB-156
        double zoomPrevious=1.0;
        double valueZoom=1.0;
        Gdk.Rectangle rectZoom;
        private void SetZoom(double newZoom)
        {
        if (!(newZoom==zoomPrevious && newZoom==1))  
            {
             m_scopeCanvasWidget.ExperimentCanvas.View.Scale = newZoom;
             // HERZUM SPRINT 5.3: TLAB-185
             rectZoom = new Gdk.Rectangle ();
             rectZoom.Height= (int)((PaddingBottom-10-edgeBorder)*newZoom);
             rectZoom.Width = (int)((PaddingLeft * 2 + ExperimentNode.Data.Metadata.Label.Length * 6-edgeBorder)*newZoom);
             // HERZUM SPRINT 2.4: TLAB-156
             rectZoom.X = (int)((rect2.X+edgeBorder+offsetPanX)*newZoom);
             rectZoom.Y = (int)((rect2.Y2+edgeBorder+offsetPanY)*newZoom);
             // END HERZUM SPRINT 5.3: TLAB-185
             // END HERZUM SPRINT 2.4: TLAB-156
             m_scopeCanvasWidget.Allocation=rectZoom;
             zoomPrevious = newZoom;
             valueZoom = newZoom;
             if (newZoom==1)
                    ecp.RedrawScope (m_scopeCanvasWidget,  rect.X+edgeBorder+offsetPanX, rect2.Y2+edgeBorder+offsetPanY);

            }
        }


        public override void AdaptsZoom(double newZoom)
        {
            m_scopeCanvasWidget.ExperimentCanvas.View.Scale = newZoom;
        }
        //HERZUM END SPRINT 2: TLAB-156

        //HERZUM SPRINT 2.0 TLAB-135
        protected void OverlayScope (ApplicationContext applicationContext) 
        {
            ScopeNodeControl sncBrother;
            ScopeNodeBase scopeNodeBrother;

            Gdk.Rectangle areaBrother = new Gdk.Rectangle();
            Gdk.Rectangle areaTarget = new Gdk.Rectangle();
            BasicNodeControl componentControl;
            ScopeNodeBase scopeNodeTarget = ExperimentNode as ScopeNodeBase;
            GetSizeAreaWidget (out areaTarget.X, out areaTarget.Y, out areaTarget.Width, out areaTarget.Height);

            foreach (ExperimentNode node in ExperimentNode.Owner.Vertices)
            {
                if (!node.Equals(ExperimentNode))
                {
                    scopeNodeBrother= node as ScopeNodeBase;
                    if (scopeNodeBrother != null)
                    {
                        if (m_applicationContext.NodeControlFactory.TryGetNodeControl (node, out componentControl))
                        {
                            sncBrother = componentControl as ScopeNodeControl;
                            sncBrother.GetSizeAreaWidget(out areaBrother.X, out areaBrother.Y, out areaBrother.Width, out areaBrother.Height);

                            if (areaTarget.IntersectsWith(areaBrother) && sncBrother.stateWidget!="iconized")
                            {
                                sncBrother.IconizeScope();
                                sncBrother.IconisationForced = true;
                            }
                            else 
                                if (!areaTarget.IntersectsWith(areaBrother) && sncBrother.IconisationForced)
                                {
                                  sncBrother.NormalizeScope();
                                  sncBrother.IconisationForced = false;
                                }
                         }

                    }
                }
            }
        }
        //END HERZUM SPRINT 2.0 TLAB-135
    }

}