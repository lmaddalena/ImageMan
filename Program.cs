using System;
using System.Drawing;


namespace ImageMan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // load the image
                System.Console.WriteLine("Loading image....");
                Bitmap bmp = new Bitmap("images\\four.png");

                // convert to gray scale
                System.Console.WriteLine("Convert to gray scale");
                Bitmap bmpgray = ToGrayScale(bmp);

                // convert to BW
                System.Console.WriteLine("Convert to BW");
                Bitmap bmpBW = ToBW(bmp);

                // convert to gray and white
                System.Console.WriteLine("Invert to Gray/White");
                Bitmap bmpInv = Invert(bmpBW);

                // resize
                System.Console.WriteLine("Resize to 20x20");
                Bitmap thumb = Resize(20, 20, bmpInv);

                // save the images
                bmpgray.Save("images\\grayscale.png");
                bmpBW.Save("images\\bw.png");
                bmpInv.Save("images\\inv.png");
                thumb.Save("images\\thumb.png");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press [ENTER] to quit");
            Console.ReadLine();
        }

        static Bitmap Resize(int w, int h, Bitmap bmp)
        {
            Bitmap b = new Bitmap(bmp, new Size(w, h));
            return b;
        }

        static Bitmap Invert(Bitmap bmp)
        {
            Bitmap bmpConv = new Bitmap(bmp);

            int w = bmp.Width;
            int h = bmp.Height;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c = bmpConv.GetPixel(x, y);

                    // pixel component
                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    // average value of RGB
                    if(r == b && b == g && g == 0)                    
                        // set pixcel
                        bmpConv.SetPixel(x, y, Color.White);   
                    else
                        bmpConv.SetPixel(x, y, Color.Gray);   
                }

            }

            return bmpConv;
        }


        static Bitmap ToGrayScale(Bitmap bmp)
        {
            Bitmap bmpConv = new Bitmap(bmp);
            int w = bmp.Width;
            int h = bmp.Height;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c = bmpConv.GetPixel(x, y);

                    // pixel component
                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    // average value of RGB
                    int avg = (r + g + b) /3;

                    // set pixcel
                    bmpConv.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));   
                }

            }

            return bmpConv;
        }

        static Bitmap ToBW(Bitmap bmp)
        {
            Bitmap bmpConv = new Bitmap(bmp);
            int w = bmp.Width;
            int h = bmp.Height;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c = bmpConv.GetPixel(x, y);

                    // pixel component
                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    // average value of RGB
                    int avg = (r + g + b) /3;

                    // set pixcel
                    if(avg < 150)
                        bmpConv.SetPixel(x, y, Color.Black);   
                    else
                        bmpConv.SetPixel(x, y, Color.White);   
                }

            }

            return bmpConv;
        }        
    }
}
