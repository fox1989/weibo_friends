﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="weiboWebApp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<style>

.node {
/*  stroke: #fff;
  stroke-width: 1.5px;*/
}

.link {
/*  fill: none;
  stroke: #bbb;*/
  fill: none;
/*  stroke: #666;*/
  stroke-width: 0.5px;
}

text {
  pointer-events: none;
/*  font: 12px normal;*/
  font:  12px normal "宋体",Arial,Times;
  fill:  white;
}

</style>
<body>
    
    <div style="text-align:center">
    <form id="form1" runat="server">
    
    <input id="Text1" type="text" value="" />&nbsp; 到&nbsp;<input id="Text2" type="text" value="" />&nbsp;
&nbsp;&nbsp;&nbsp;<input id="Button2" type="button" value="ajax" onclick="getjson();" />&nbsp;&nbsp;
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="关系" />
    
    </form>
    </div>
    <div>
    
    
    </div>
    <script type="text/javascript" src="Scripts/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="Scripts/d3.v3.min.js"></script>
    <script type="text/javascript">


        var graph;
        var graph = {
            "links": [{
                "source": "0",
                "target": "1",
                "value": "2"
            }, {
                "source": "2",
                "target": "3",
                "value": "2"
            }, {
                "source": "4",
                "target": "5",
                "value": "2"
            }, {
                "source": "6",
                "target": "7",
                "value": "2"
            }, {
                "source": "8",
                "target": "1",
                "value": "1"
            }, {
                "source": "9",
                "target": "10",
                "value": "2"
            }, {
                "source": "11",
                "target": "12",
                "value": "2"
            }, {
                "source": "8",
                "target": "5",
                "value": "1"
            }, {
                "source": "13",
                "target": "14",
                "value": "2"
            }, {
                "source": "15",
                "target": "16",
                "value": "2"
            }, {
                "source": "17",
                "target": "18",
                "value": "2"
            }, {
                "source": "19",
                "target": "12",
                "value": "2"
            }, {
                "source": "20",
                "target": "21",
                "value": "2"
            }, {
                "source": "8",
                "target": "22",
                "value": "1"
            }, {
                "source": "17",
                "target": "1",
                "value": "2"
            }, {
                "source": "4",
                "target": "23",
                "value": "2"
            }, {
                "source": "24",
                "target": "13",
                "value": "2"
            }, {
                "source": "8",
                "target": "25",
                "value": "1"
            }, {
                "source": "26",
                "target": "27",
                "value": "2"
            }, {
                "source": "28",
                "target": "29",
                "value": "2"
            }, {
                "source": "8",
                "target": "13",
                "value": "1"
            }, {
                "source": "11",
                "target": "1",
                "value": "2"
            }, {
                "source": "8",
                "target": "30",
                "value": "1"
            }, {
                "source": "5",
                "target": "22",
                "value": "2"
            }, {
                "source": "31",
                "target": "32",
                "value": "2"
            }, {
                "source": "8",
                "target": "15",
                "value": "1"
            }, {
                "source": "8",
                "target": "2",
                "value": "1"
            }, {
                "source": "8",
                "target": "33",
                "value": "1"
            }, {
                "source": "8",
                "target": "27",
                "value": "1"
            }, {
                "source": "8",
                "target": "11",
                "value": "1"
            }, {
                "source": "2",
                "target": "23",
                "value": "2"
            }, {
                "source": "34",
                "target": "28",
                "value": "2"
            }, {
                "source": "32",
                "target": "21",
                "value": "2"
            }, {
                "source": "0",
                "target": "26",
                "value": "2"
            }, {
                "source": "2",
                "target": "19",
                "value": "2"
            }, {
                "source": "0",
                "target": "28",
                "value": "2"
            }, {
                "source": "2",
                "target": "28",
                "value": "2"
            }, {
                "source": "20",
                "target": "35",
                "value": "2"
            }, {
                "source": "2",
                "target": "34",
                "value": "2"
            }, {
                "source": "8",
                "target": "36",
                "value": "1"
            }, {
                "source": "6",
                "target": "10",
                "value": "2"
            }, {
                "source": "8",
                "target": "37",
                "value": "1"
            }, {
                "source": "19",
                "target": "26",
                "value": "2"
            }, {
                "source": "11",
                "target": "29",
                "value": "2"
            }, {
                "source": "8",
                "target": "0",
                "value": "1"
            }, {
                "source": "8",
                "target": "38",
                "value": "1"
            }, {
                "source": "20",
                "target": "39",
                "value": "2"
            }, {
                "source": "27",
                "target": "17",
                "value": "2"
            }, {
                "source": "31",
                "target": "39",
                "value": "2"
            }, {
                "source": "40",
                "target": "28",
                "value": "2"
            }, {
                "source": "36",
                "target": "3",
                "value": "2"
            }, {
                "source": "12",
                "target": "26",
                "value": "2"
            }, {
                "source": "8",
                "target": "17",
                "value": "1"
            }, {
                "source": "41",
                "target": "42",
                "value": "2"
            }, {
                "source": "0",
                "target": "17",
                "value": "2"
            }, {
                "source": "8",
                "target": "35",
                "value": "1"
            }, {
                "source": "8",
                "target": "29",
                "value": "1"
            }, {
                "source": "8",
                "target": "43",
                "value": "1"
            }, {
                "source": "0",
                "target": "27",
                "value": "2"
            }, {
                "source": "44",
                "target": "28",
                "value": "2"
            }, {
                "source": "8",
                "target": "44",
                "value": "1"
            }, {
                "source": "40",
                "target": "3",
                "value": "2"
            }, {
                "source": "24",
                "target": "41",
                "value": "2"
            }, {
                "source": "8",
                "target": "3",
                "value": "1"
            }, {
                "source": "34",
                "target": "5",
                "value": "2"
            }, {
                "source": "19",
                "target": "17",
                "value": "2"
            }, {
                "source": "5",
                "target": "45",
                "value": "2"
            }, {
                "source": "8",
                "target": "9",
                "value": "1"
            }, {
                "source": "5",
                "target": "28",
                "value": "2"
            }, {
                "source": "30",
                "target": "19",
                "value": "2"
            }, {
                "source": "3",
                "target": "17",
                "value": "2"
            }, {
                "source": "8",
                "target": "32",
                "value": "1"
            }, {
                "source": "12",
                "target": "25",
                "value": "2"
            }, {
                "source": "8",
                "target": "31",
                "value": "1"
            }, {
                "source": "8",
                "target": "26",
                "value": "1"
            }, {
                "source": "8",
                "target": "45",
                "value": "1"
            }, {
                "source": "8",
                "target": "42",
                "value": "1"
            }, {
                "source": "28",
                "target": "1",
                "value": "2"
            }, {
                "source": "34",
                "target": "27",
                "value": "2"
            }, {
                "source": "8",
                "target": "12",
                "value": "1"
            }, {
                "source": "8",
                "target": "4",
                "value": "1"
            }, {
                "source": "0",
                "target": "3",
                "value": "2"
            }, {
                "source": "32",
                "target": "39",
                "value": "2"
            }, {
                "source": "26",
                "target": "1",
                "value": "2"
            }, {
                "source": "8",
                "target": "46",
                "value": "1"
            }, {
                "source": "12",
                "target": "1",
                "value": "2"
            }, {
                "source": "0",
                "target": "19",
                "value": "2"
            }, {
                "source": "11",
                "target": "28",
                "value": "2"
            }, {
                "source": "11",
                "target": "34",
                "value": "2"
            }, {
                "source": "3",
                "target": "22",
                "value": "2"
            }, {
                "source": "5",
                "target": "42",
                "value": "2"
            }, {
                "source": "0",
                "target": "11",
                "value": "2"
            }, {
                "source": "35",
                "target": "21",
                "value": "2"
            }, {
                "source": "2",
                "target": "27",
                "value": "2"
            }, {
                "source": "0",
                "target": "12",
                "value": "2"
            }, {
                "source": "31",
                "target": "21",
                "value": "2"
            }, {
                "source": "19",
                "target": "3",
                "value": "2"
            }, {
                "source": "8",
                "target": "16",
                "value": "1"
            }, {
                "source": "3",
                "target": "26",
                "value": "2"
            }, {
                "source": "29",
                "target": "1",
                "value": "2"
            }, {
                "source": "8",
                "target": "40",
                "value": "1"
            }, {
                "source": "15",
                "target": "13",
                "value": "2"
            }, {
                "source": "12",
                "target": "17",
                "value": "2"
            }, {
                "source": "46",
                "target": "18",
                "value": "2"
            }, {
                "source": "34",
                "target": "17",
                "value": "2"
            }, {
                "source": "8",
                "target": "41",
                "value": "1"
            }, {
                "source": "8",
                "target": "10",
                "value": "1"
            }, {
                "source": "19",
                "target": "27",
                "value": "2"
            }, {
                "source": "8",
                "target": "39",
                "value": "1"
            }, {
                "source": "8",
                "target": "6",
                "value": "1"
            }, {
                "source": "35",
                "target": "31",
                "value": "2"
            }, {
                "source": "28",
                "target": "37",
                "value": "2"
            }, {
                "source": "8",
                "target": "23",
                "value": "1"
            }, {
                "source": "8",
                "target": "47",
                "value": "1"
            }, {
                "source": "11",
                "target": "17",
                "value": "2"
            }, {
                "source": "8",
                "target": "14",
                "value": "1"
            }, {
                "source": "24",
                "target": "4",
                "value": "2"
            }, {
                "source": "28",
                "target": "17",
                "value": "2"
            }, {
                "source": "8",
                "target": "19",
                "value": "1"
            }, {
                "source": "41",
                "target": "13",
                "value": "2"
            }, {
                "source": "16",
                "target": "28",
                "value": "2"
            }, {
                "source": "26",
                "target": "17",
                "value": "2"
            }, {
                "source": "3",
                "target": "28",
                "value": "2"
            }, {
                "source": "13",
                "target": "45",
                "value": "2"
            }, {
                "source": "41",
                "target": "15",
                "value": "2"
            }, {
                "source": "20",
                "target": "32",
                "value": "2"
            }, {
                "source": "42",
                "target": "45",
                "value": "2"
            }, {
                "source": "22",
                "target": "28",
                "value": "2"
            }, {
                "source": "20",
                "target": "31",
                "value": "2"
            }, {
                "source": "11",
                "target": "3",
                "value": "2"
            }, {
                "source": "19",
                "target": "1",
                "value": "2"
            }, {
                "source": "8",
                "target": "34",
                "value": "1"
            }, {
                "source": "35",
                "target": "39",
                "value": "2"
            }, {
                "source": "8",
                "target": "18",
                "value": "1"
            }, {
                "source": "12",
                "target": "3",
                "value": "2"
            }, {
                "source": "8",
                "target": "24",
                "value": "1"
            }, {
                "source": "8",
                "target": "20",
                "value": "1"
            }, {
                "source": "8",
                "target": "48",
                "value": "1"
            }, {
                "source": "8",
                "target": "21",
                "value": "1"
            }, {
                "source": "8",
                "target": "28",
                "value": "1"
            }, {
                "source": "24",
                "target": "10",
                "value": "2"
            }, {
                "source": "35",
                "target": "32",
                "value": "2"
            }, {
                "source": "34",
                "target": "3",
                "value": "2"
            }, {
                "source": "21",
                "target": "39",
                "value": "2"
            }, {
                "source": "40",
                "target": "22",
                "value": "2"
            }, {
                "source": "41",
                "target": "10",
                "value": "2"
            }, {
                "source": "8",
                "target": "7",
                "value": "1"
            }],
            "nodes": [{
                "count": 10,
                "group": "2",
                "name": "金容君-邻家王子"
            }, {
                "count": 9,
                "group": "2",
                "name": "王一鹤_"
            }, {
                "count": 7,
                "group": "2",
                "name": "苍井空贴吧官方微博"
            }, {
                "count": 13,
                "group": "2",
                "name": "沈永阁"
            }, {
                "count": 4,
                "group": "2",
                "name": "肖飞"
            }, {
                "count": 7,
                "group": "2",
                "name": "中山邦夫"
            }, {
                "count": 3,
                "group": "2",
                "name": "Juno?浚?"
            }, {
                "count": 2,
                "group": "2",
                "name": "?精甫WongChingPo"
            }, {
                "count": 15,
                "group": "1",
                "name": "苍井空"
            }, {
                "count": 2,
                "group": "2",
                "name": "岩井俊二"
            }, {
                "count": 5,
                "group": "2",
                "name": "彭浩翔"
            }, {
                "count": 9,
                "group": "2",
                "name": "Y-star小?哥"
            }, {
                "count": 9,
                "group": "2",
                "name": "张佑荣"
            }, {
                "count": 6,
                "group": "2",
                "name": "杨幂"
            }, {
                "count": 2,
                "group": "2",
                "name": "刘春"
            }, {
                "count": 4,
                "group": "2",
                "name": "张晗"
            }, {
                "count": 3,
                "group": "2",
                "name": "王才涛"
            }, {
                "count": 12,
                "group": "2",
                "name": "赵元?-邻家王子"
            }, {
                "count": 3,
                "group": "2",
                "name": "左疼右爱_佐藤?"
            }, {
                "count": 10,
                "group": "2",
                "name": "竹书娱乐"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量廷廷"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量嘎嘎"
            }, {
                "count": 5,
                "group": "2",
                "name": "松冈"
            }, {
                "count": 3,
                "group": "2",
                "name": "何大叶"
            }, {
                "count": 5,
                "group": "2",
                "name": "?承?"
            }, {
                "count": 2,
                "group": "2",
                "name": "侯琳飞"
            }, {
                "count": 8,
                "group": "2",
                "name": "邻家王子组合"
            }, {
                "count": 7,
                "group": "2",
                "name": "小揪儿"
            }, {
                "count": 15,
                "group": "2",
                "name": "程_孝明"
            }, {
                "count": 4,
                "group": "2",
                "name": "9111NINA"
            }, {
                "count": 2,
                "group": "2",
                "name": "张阿牧"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量鼓手阿翔"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量??"
            }, {
                "count": 1,
                "group": "2",
                "name": "山田尚"
            }, {
                "count": 8,
                "group": "2",
                "name": "服装师喜一"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量雷堡"
            }, {
                "count": 2,
                "group": "2",
                "name": "梅派-胡文阁"
            }, {
                "count": 2,
                "group": "2",
                "name": "魔女mok"
            }, {
                "count": 1,
                "group": "2",
                "name": "多多罗文化"
            }, {
                "count": 6,
                "group": "2",
                "name": "MP魔幻力量鼓鼓"
            }, {
                "count": 4,
                "group": "2",
                "name": "松冈伸弥"
            }, {
                "count": 6,
                "group": "2",
                "name": "王中磊"
            }, {
                "count": 4,
                "group": "2",
                "name": "real阿兰"
            }, {
                "count": 1,
                "group": "2",
                "name": "马戎戎"
            }, {
                "count": 2,
                "group": "2",
                "name": "MIYAVI_OFFICIAL"
            }, {
                "count": 4,
                "group": "2",
                "name": "欧弟"
            }, {
                "count": 2,
                "group": "2",
                "name": "李缨电影"
            }, {
                "count": 1,
                "group": "2",
                "name": "他回精神病院了"
            }, {
                "count": 1,
                "group": "2",
                "name": "benylan"
            }]
        }

        function getjson() {

            var strname1 = $("#Text1").val();
            var strname2 = $("#Text2").val();
            var datastr = "strname1=" + strname1 + "&strname2=" + strname2;
            alert(datastr);
            $.ajax({
                type: "POST",
                url: "dispose.aspx",
                dataType: "json",
                data: datastr,

                success: function (msg) {


                    graph = msg;
                    $("path").remove();
                    $("g").remove();
                    show();


                }
            });


 }
            var width = 1366,
     height =642;

            var color = d3.scale.category20();

            var force = d3.layout.force().linkDistance(100).linkStrength(2).charge(-300).size([width, height]);

            var svg = d3.select("body").append("svg").attr("width", width).attr("height", height);

            // 背景
            d3.select("body").transition().style("background-color", "grey");
            d3.select("body").append("span").text("In fox! ");


            function show() { 
            
            var nodes = graph.nodes.slice(),
     links = [],
     bilinks = [];

        graph.links.forEach(function (link) {
            var s = nodes[link.source],
          t = nodes[link.target],
          i = {}; // intermediate node
            v = link.value;
            nodes.push(i);
            links.push({
                source: s,
                target: i
            }, {
                source: i,
                target: t
            });
            bilinks.push([s, i, t, v]);
        });

        force.nodes(nodes).links(links).start();

        var link = svg.selectAll(".link").data(bilinks)
                  .enter().append("path")
                  .attr("class", "link")
                  .style("stroke", function (d) {
                      //console.log(d);
                      if (d[3] != null) {
                          if (d[3] == "1") {
                              //  console.log(d[3]);
                              return color("1");
                          } else {
                              return color("2");
                          }
                      };
                  });

        var node = svg.selectAll(".node").data(graph.nodes)
                  .enter().append("g")
                  .attr("class", "node")
                  .call(force.drag);

        //小圆   2.5-7.5
        node.append("circle").attr("class", "node")
              .attr("r", function (d) {
                  console.log(d.count / 2)
                  if (d.count / 2 < 2) {
                      return 2.5;
                  } else {
                      return d.count / 2;
                  }
              })
              .style("fill", function (d) {
                  //      console.log(d);
                  //      return color(d.group);
                  return color(d.count + "")
              });


        node.append("text")
                .attr("dx", 12)
                .attr("dy", ".35em")
                .attr("class", "text")
                .text(function (d) {
                    return d.name
                });

        force.on("tick", function () {
            link.attr("d", function (d) {
                return "M" + d[0].x + "," + d[0].y + "S"
                      + d[1].x + "," + d[1].y + " "
                      + d[2].x + "," + d[2].y;
            });
            node.attr("transform", function (d) {
                return "translate(" + d.x + "," + d.y + ")";
            });
        });
            
            }
            show();
        
        // });
    
    
    
    </script>
</body>
</html>
