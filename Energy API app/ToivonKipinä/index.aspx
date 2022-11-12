<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ToivonKipinä.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toivoa vielä on</title>
    <link rel="stylesheet" href="styles.css" runat="server"/>
</head>
<body runat="server">
    <form id="form1" runat="server" method="post" action="index.aspx">
        
        <div id="container">
        <div id="header">
            <div class="logo">sähköntuotannon<span class="bold"> | seurantasovellus</span></div>
        </div>
        
        <div id="formcont">
            <div id="form">
                <input class="datepicker" type="date" id="pvm" runat="server" value=""/>
                <div id="ohjeValitse" runat="server"></div>
                <label for="ydinvoima" class="container">ydinvoima
                    <input type="checkbox" id="ydinvoima" name="ydinvoima" value="Ydinvoima" runat="server"/>
                    <span class="checkmark"></span>
                </label>
                <label for="lauhdevoima" class="container">lauhdevoima
                    <input type="checkbox" id="lauhdevoima" name="lauhdevoima" value="Lauhdevoima" runat="server"/>
                    <span class="checkmark"></span>
                </label>
                <label for="aurinkovoima" class="container">aurinkovoima
                    <input type="checkbox" id="aurinkovoima" name="aurinkovoima" value="Aurinkovoima" runat="server"/>
                    <span class="checkmark"></span>
                </label>
                <label for="tuulivoima" class="container">tuulivoima
                    <input type="checkbox" id="tuulivoima" name="tuulivoima" value="Tuulivoima" runat="server"/>
                    <span class="checkmark"></span>
                </label>
                <label for="vesivoima" class="container">vesivoima
                    <input type="checkbox" id="vesivoima" name="vesivoima" value="Vesivoima" runat="server"/>
                    <span class="checkmark"></span>
                </label>
                <div>
                    <input class="search" id="submit" type="submit" value="HAE TIEDOT" runat="server" OnServerClick="Hae_Tiedot"/>
                    
                </div>
            </div>
            
        </div>
        
        <div id="output">
            <div class="bg">
                <h3>
                    <span id="paivamaaraOutPut" runat="server"></span>
                </h3>
                <br/>
                <p id="error" runat="server"></p>

                <p id="yvResult" runat="server"></p>
                <p id="yvKoko" runat="server"></p>

                <p id="lvResult" runat="server"></p>
                <p id="lvKoko" runat="server"></p>

                <p id="avResult" runat="server"></p>
                <p id="avKoko" runat="server"></p>

                <p id="tvResult" runat="server"></p>
                <p id="tvKoko" runat="server"></p>

                <p id="vvResult" runat="server"></p>
                <p id="vvKoko" runat="server"></p>

                
            </div>
        </div>
        <div id="info">
            <div class="bg1">
                <h3>Ohjeet:</h3>
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor cupiditate fuga quia laborum excepturi."
            </div>
        </div>
        <div id="footer">
            Copyright © Prrrrr Oy 2020
        </div>
    </div>


    </form>
</body>
</html>
