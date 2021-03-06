﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System;

namespace uAdventure.Core
{
    /**
     * This class loads the e-Adventure data from a XML file
     */
    public class Loader
    {
        /**
            * AdventureData structure which has been previously read. (For Debug
            * execution)
            */
        private static AdventureData adventureData;

        /**
         * Cache the SaxParserFactory
         */
        //private static SAXParserFactory factory = SAXParserFactory.newInstance();

        /**
         * Private constructor
         */
        private Loader()
        {

        }

        public static AdventureData loadAdventureData(string path, List<Incidence> incidences)
        {
            AdventureData adventureDataTemp = new AdventureData();
            try
            {
                AdventureHandler_ adventureParser = new AdventureHandler_(adventureDataTemp);

                // Read and close the input stream
                adventureParser.Parse(path + "\\descriptor.xml");
                //descriptorIS.close();

                adventureDataTemp = adventureParser.getAdventureData();

            }
            catch (Exception e) { Debug.LogError(e); }

            return adventureDataTemp;
        }

        /**
         * @param adventureData
         *            the adventureData to set
         */
        public static void setAdventureData(AdventureData adventureData)
        {

            Loader.adventureData = adventureData;
        }

        /**
         * Loads an animation from a filename
         * 
         * @param filename
         *            The xml descriptor for the animation
         * @return the loaded Animation
         */
        public static Animation loadAnimation(InputStreamCreator isCreator, string filename, ImageLoaderFactory imageloader)
        {

            AnimationHandler_ animationHandler = new AnimationHandler_(isCreator, imageloader);

            // Create a new factory
            //factory.setValidating(false);
            //SAXParser saxParser;
            try
            {
                //saxParser = factory.newSAXParser();

                // Read and close the input stream
                //File file = new File(filename);
                string descriptorIS = null;
                /*try {
                    System.out.println("FILENAME="+filename);
                    descriptorIS = ResourceHandler.getInstance( ).buildInputStream(filename);
                    System.out.println("descriptorIS==null?"+(descriptorIS==null));

                    //descriptorIS = new InputStream(ResourceHandler.getInstance().getResourceAsURLFromZip(filename));
                } catch (Exception e) { Debug.LogError(e); } {
                    e.printStackTrace();
                }
                if (descriptorIS == null) {
                    descriptorIS = AssetsController.getInputStream(filename);
                }*/
                descriptorIS = isCreator.buildInputStream("Assets/Resources/CurrentGame/" + filename);
                if (!descriptorIS.EndsWith(".eaa"))
                    descriptorIS += ".eaa";
                animationHandler.Parse(descriptorIS);
                //saxParser.parse(descriptorIS, animationHandler);
                //descriptorIS.close();

            }
            catch (Exception e) { Debug.LogError(e); }
            //catch (ParserConfigurationException e)
            //{
            //    e.printStackTrace();
            //    System.err.println(filename);
            //}
            //catch (SAXException e)
            //{
            //    e.printStackTrace();
            //    System.err.println(filename);
            //}
            //catch (FileNotFoundException e)
            //{
            //    e.printStackTrace();
            //    System.err.println(filename);
            //}
            //catch (IOException e)
            //{
            //    e.printStackTrace();
            //    System.err.println(filename);
            //}

            if (animationHandler.getAnimation() != null)
                return animationHandler.getAnimation();
            else
                return new Animation("anim" + (new System.Random()).Next(1000), imageloader);
        }

        /**
         * Returns true if the given file contains an eAdventure game from a newer
         * version. Essentially, it looks for the "ead.properties" file in the new
         * eAdventure games. If it's found, then returns true
         * 
         * @param f
         *            the file to check
         * @return if the game requires a newer version
         */
        //public static bool requiresNewVersion(java.io.File f)
        //{
        //    bool isOldProject = true;
        //    FileInputStream in = null;
        //    ZipInputStream zipIn = null;
        //    try
        //    {
        //        in = new FileInputStream(f);
        //        zipIn = new ZipInputStream( in );
        //        ZipEntry zipEntry = null;
        //        while ((zipEntry = zipIn.getNextEntry()) != null)
        //        {
        //            if (zipEntry.getName().endsWith("ead.properties"))
        //            {
        //                isOldProject = false;
        //            }
        //        }
        //        zipIn.close();
        //    }
        //    catch (IOException e)
        //    {

        //    }
        //    finally
        //    {
        //        if ( in != null ) {
        //            try
        //            {
        //                in.close();
        //            }
        //            catch (IOException e)
        //            {

        //            }
        //        }

        //        if (zipIn != null)
        //        {
        //            try
        //            {
        //                zipIn.close();
        //            }
        //            catch (IOException e)
        //            {
        //            }
        //        }
        //    }
        //    return !isOldProject;
        //}
    }
}