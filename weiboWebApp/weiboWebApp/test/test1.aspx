<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="weiboWebApp.test.test1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" action="">
    <p></p>
    <input id="Button1" type="button" value="button" onclick="gettext();"/><input id="Text1" 
        type="text" /></form>
    <script type="text/jscript" src="../Scripts/jquery-1.8.3.min.js"></script>

    <script type="text/jscript" >

        function gettext() {


            $.ajax({
                type: "POST",
                url: "test2.aspx",
                dataType: "json",
                data: "name=fox&age=24",

                success: function (msg) {
                    var ss = msg;
                    //var json = eval( ss); 
                    //  var json = jQuery.parseJSON(ss);
                    $("p").html(ss);
                    alert("Data Saved: " + ss.age);
                }
            });


//            $.ajax({
//                type: "get",
//                cache: false,
//                url: "test2.aspx",
//              //  data: { AT: at},
//                dataType: "json",
//                success: function (json) {
//                    alert(json.age);

//                }
//            });

           
                 }
           

        // var str='{"name":"fox"}';
        // var json=JSON.parse(str);
         //alert(json.name);

         
                 
          //  $.get("test2.aspx", { user: "fox", age: "24" }, function (data) { $("p").html(data) });
     

    
    </script>
</body>
</html>
