using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace AgSwift_GUI
{
    class Project
    {
        private string projectTitle;
        private double scaleFactor;
        private string dir;

        private Dictionary<string, List<ImageClickable>> bluePrintImages;
        private Dictionary<string, List<PointClickable>> bluePrintPoints;
        private Dictionary<string, List<EdgeClickable>> bluePrintEdges;

        public Project()
        {
            bluePrintImages = new Dictionary<string, List<ImageClickable>>();
            bluePrintPoints = new Dictionary<string, List<PointClickable>>();
            bluePrintEdges = new Dictionary<string, List<EdgeClickable>>();

            bluePrintPoints["Existing"] = new List<PointClickable>();
            bluePrintEdges["Existing"] = new List<EdgeClickable>();
            bluePrintImages["Existing"] = new List<ImageClickable>();

            bluePrintPoints["Proposed"] = new List<PointClickable>();
            bluePrintEdges["Proposed"] = new List<EdgeClickable>();
            bluePrintImages["Proposed"] = new List<ImageClickable>();
        }

        public void loadProject(string path)
        {
            dir = path;
            byte[] file_contents;
            string file_string;
            string[] file_string_array;
            FileStream fs;
            try
            {
                fs = File.Open(path, FileMode.Open);
                file_contents = new byte[fs.Length - 1];
                fs.Read(file_contents, 0, (int)fs.Length - 1);
                file_string = Encoding.UTF8.GetString(file_contents);
                file_string_array = file_string.Split('\n');

                string current_bp = "";
                bool getting_edges = false;
                bool getting_images = false;

                try
                {
                    foreach (string s in file_string_array)
                    {
                        if (s.Contains("###"))
                        {
                            if (s.Contains("END"))
                            {
                                current_bp = "";
                            }
                            else
                            {
                                current_bp = s.Remove(0, 3);
                                bluePrintPoints[current_bp] = new List<PointClickable>();
                                bluePrintEdges[current_bp] = new List<EdgeClickable>();
                                bluePrintImages[current_bp] = new List<ImageClickable>();
                            }
                        }
                        else if(s.Contains("##"))
                        {
                            if(s.Contains("EDGES"))
                            {
                                getting_edges = true;
                                getting_images = false;
                            }
                            else if(s.Contains("IMAGES"))
                            {
                                getting_edges = false;
                                getting_images = true;
                            }
                            else if(s.Contains("STOP"))
                            {
                                getting_edges = false;
                                getting_images = false;
                            }
                        }
                        else
                        {
                            if(getting_images)
                            {
                                string[] vars = s.Split(',');
                                Image img = Image.FromFile(vars[2]);
                                ImageClickable ic = new ImageClickable(img, new SwiftAg_CS.Point(Double.Parse(vars[0]), Double.Parse(vars[1]), 0), vars[2]);
                                bluePrintImages[current_bp].Add(ic);
                            }
                            else if(getting_edges)
                            {
                                string[] vars = s.Split(',');
                                double x1 = Double.Parse(vars[0]);
                                double y1 = Double.Parse(vars[1]);
                                double e1 = Double.Parse(vars[2]);

                                double x2 = Double.Parse(vars[3]);
                                double y2 = Double.Parse(vars[4]);
                                double e2 = Double.Parse(vars[5]);

                                PointClickable a = new PointClickable(x1, y1, e1);
                                PointClickable b = new PointClickable(x2, y2, e2);

                                EdgeClickable ab = new EdgeClickable(a, b);
                                EdgeClickable ab_dup = new EdgeClickable(b, a);

                                if (!bluePrintPoints[current_bp].Contains(a))
                                {
                                    bluePrintPoints[current_bp].Add(a);
                                }
                                if (!bluePrintPoints[current_bp].Contains(b))
                                {
                                    bluePrintPoints[current_bp].Add(b);
                                }
                                if (!bluePrintEdges[current_bp].Contains(ab) && !bluePrintEdges[current_bp].Contains(ab_dup))
                                {
                                    bluePrintEdges[current_bp].Add(ab);
                                }
                            }
                        }
                    }
                }
                catch(Exception e)
                {

                }
            }
            catch(Exception e)
            {

            }
        }

        public void saveProject(string path)
        {
            dir = path;
            FileStream fs;
            fs = File.Open(path, FileMode.OpenOrCreate);

            string file_string = "";

            foreach (string key in bluePrintPoints.Keys)
            {
                //Start by defining the blueprint
                string blueprintHeader = "###" + key + "\n";
                file_string += blueprintHeader;

                file_string += "##EDGES\n";
                //Now the edges
                foreach(EdgeClickable _e in bluePrintEdges[key])
                {
                    string x1 = _e.get_a().get_x().ToString();
                    string x2 = _e.get_b().get_x().ToString();
                    string e1 = _e.get_a().get_elevation().ToString();
                    string y1 = _e.get_a().get_y().ToString();
                    string y2 = _e.get_b().get_y().ToString();
                    string e2 = _e.get_b().get_elevation().ToString();

                    string edge_str = x1 + "," + y1 + "," + e1 + "," + x2 + "," + y2 + "," + e2 + "\n";
                    file_string += edge_str;
                }
                file_string += "##STOP\n";

                file_string += "##IMAGES\n";
                //Then the images
                foreach(ImageClickable _i in bluePrintImages[key])
                {
                    string x = _i.getTopLeftCorner().get_x().ToString();
                    string y = _i.getTopLeftCorner().get_y().ToString();
                    string img_dir = _i.getImageDir();

                    string image_str = x + "," + y + "," + img_dir + "\n";
                    file_string += image_str;
                }
                file_string += "##STOP\n";
                file_string += "###END\n";
            }
            byte[] file_obj = Encoding.UTF8.GetBytes(file_string);
            fs.Write(file_obj, 0, file_obj.Length);
            fs.Close();
        }

        public List<PointClickable> getBluePrintPoints(string _blueprint)
        {
            return bluePrintPoints[_blueprint];
        }

        public List<EdgeClickable> getBluePrintEdges(string _blueprint)
        {
            return bluePrintEdges[_blueprint];
        }

        public List<ImageClickable> getBluePrintImages(string _blueprint)
        {
            return bluePrintImages[_blueprint];
        }

        public string getProjectDirectory()
        {
            return dir;
        }

        public void addEdgeList(string _key, List<EdgeClickable> _edges)
        {
            bluePrintEdges[_key] = _edges;
            bluePrintPoints[_key] = new List<PointClickable>();
        }
        public void addImageList(string _key, List<ImageClickable> _images)
        {
            bluePrintImages[_key] = _images;
        }
    }
}
