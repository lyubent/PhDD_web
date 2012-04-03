<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TermsAndConditions.aspx.cs" Inherits="TermsAndConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="wrapper">

<h1>Resources We Used</h1>

<p1>Below are acknowledgemnts of tools that the team INDEXER used to create the phDD application. Thanks to everyone who made
    made this dream possible. </p1>


<div class="img">

    <a href="http://pipes.yahoo.com/pipes/">
    <img src="Images/pipeslogo_whitebg.gif" width="auto" height="auto" align="left"/>
    </a>
    <div class="desc">

       <p2>We made use of Yahoo pipes to take information from an xml file from our page, retrieves the information out of it and sends it back to the web 
       page. Beautiful</p2>


    </div>
</div>


<div class="img">
<a href="http://developer.yahoo.com/yui/">
  <img src="Images/yui.png"  width="auto" height="auto"  align="left" />
   </a>
    <div class="desc">
    <p2>We found Yui to be a very powerful tool for setting up the layouts for the pipes. Yui was created by Yahoo and 
        has many powerful open source tools available to be played with. Check it out!</p2>


    </div> 
</div>


<div class="img">
<a href="http://www.mysql.com/products/workbench/">
  <img src="Images/mysql.jpg"  width="auto" height="auto" align="left" />  
  </a>
  <div class="desc">
   
   <p2>Sql Workbench was the tool of choice for our database needs. We used a relation database for storage and retrievel of HDD 
       information that we extracted. Workbench is easy to use and matched all our requirements to implement HDD data.</p2>

     
     </div>
</div>



<div class="img">
<a href="http://www.microsoft.com/visualstudio/en-gb?wt.mc_id=src-n-gb-Non-loc-F7-NonGA">
    <img src="Images/VisualStudio.png"  width="auto" height="auto" align="left" />
 </a>  
    <div class="desc">
    
     <p2>The vast majority of our coding was done using Visual Studio 2010. It was the perfect development enviroment for us 
         as it contains every tool we needed to utilize. Coding was done in C# and our are web pages were made with Asp. Visual Studio is
         available for free download if you are a student so get your hands on this invaluable software.</p2>
      
      
      </div>

      </div>

      <div class="img">
      <a href="https://www.google.com/chrome/?installdataindex=nosearch&hl=en-GB&brand=CHMA&utm_campaign=en-GB&utm_source=en-GB-ha-emea-uk-bk&utm_medium=ha">
    <img src="Images/chrome-icon.jpg"  width="auto" height="auto" align="left" />
   </a>
    <div class="desc">
    
      <p2>The main browser of choice for testing puproses was Google Chrome. As it is so commonly used it made sense to develop in this enviroment. 
      Our website was obviously tested on every other browser out there!</p2>
      
      
      </div>
</div>

</div>







</div>

</asp:Content>
