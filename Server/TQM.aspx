<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TQM.aspx.vb" Inherits="TQM.WebForm1" %>
<%@ Register assembly="DevExpress.Web.v15.1, Version=15.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
        .auto-style1 {
            height: 24px;
           text-align:center;
        }
      Tr .TrCenter {
             text-align: center;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style4 {
            width: 73px;
        }
        .auto-style5 {
            height: 23px;
            width: 73px;
        }
        .auto-style6 {
            height: 24px;
            width: 73px;
        }
        .auto-style7 {
            height: 24px;
            text-align: center;
            width: 73px;
        }
        .auto-style8 {
            width: 120px;
        }
        .auto-style9 {
            height: 23px;
            width: 120px;
        }
        .auto-style10 {
            height: 24px;
            width: 120px;
        }
        .auto-style11 {
            height: 24px;
            text-align: center;
            width: 120px;
        }
        .auto-style12 {
            width: 84px;
        }
        .auto-style13 {
            height: 23px;
            width: 84px;
        }
        .auto-style14 {
            height: 24px;
            width: 84px;
        }
        .auto-style15 {
            height: 24px;
            text-align: center;
            width: 84px;
        }
        .auto-style16 {
            width: 58px;
        }
        .auto-style17 {
            height: 23px;
            width: 58px;
        }
        .auto-style18 {
            height: 24px;
            width: 58px;
        }
        .auto-style19 {
            height: 24px;
            text-align: center;
            width: 58px;
        }
    </style>

</head>
<body>
<form id="theForm" runat="server" width="100%" height="100%">
     <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" ShowCollapseBackwardButton="True" Height="800px">
         <Panes>
             <dx:SplitterPane size="90%">
                 <ContentCollection>
                     <dx:SplitterContentControl runat="server" >
                         <table >
        <tr  class="auto-style1">
    <td>A</td>
    <td>B</td> 
    <td class="auto-style8">C</td>
    <td class="auto-style12">D</td>
          <td>E</td>
    <td class="auto-style4">F</td> 
    <td>G</td>
    <td class="auto-style16">H</td>
          <td>I</td>
    <td>J</td> 
    <td>K</td>
   
    <td>L</td>
   
  </tr>
<tr  class="auto-style1">
    <td rowspan="3">OID</td>
    <td rowspan="3">Description<Description</td> 
    <td colspan="5" style="background-color: #C6FCFD; font-weight: bold;">Information</td>
    <td colspan="5" style="background-color: #3333CC; color: #FFFF00; font-weight: bold;">Action</td>
   
  </tr>
  <tr align="Center">
    <td class="auto-style8" style="background-color: #C6FCFD">1</td>
      <td class="auto-style12" style="background-color: #C6FCFD">2</td>
          <td style="background-color: #C6FCFD">3</td>
    <td class="auto-style4" style="background-color: #C6FCFD">4</td> 
    <td style="background-color: #C6FCFD">0</td>
    <td class="auto-style16" style="background-color: #3333CC; color: #FFFF00;">5</td>
          <td style="background-color: #3333CC; color: #FFFF00;">6</td>
    <td style="background-color: #3333CC; color: #FFFF00;">7</td> 
    <td style="background-color: #3333CC; color: #FFFF00;">8</td>
   
    <td style="background-color: #3333CC; color: #FFFF00;">9</td>
   
  </tr>
        <tr align="Center">
    <td class="auto-style9" style="background-color: #C6FCFD" >Source Code</td>
    <td class="auto-style13" style="background-color: #C6FCFD">Data</td>
          <td class="auto-style2" style="background-color: #C6FCFD">System</td>
    <td class="auto-style5" style="background-color: #C6FCFD">Key</td> 
    <td class="auto-style2" style="background-color: #C6FCFD">Plus Or Less</td>
    <td class="auto-style17" style="background-color: #3333CC; color: #FFFF00;">Plan</td>
          <td class="auto-style2" style="background-color: #3333CC; color: #FFFF00;">Do</td>
    <td class="auto-style2" style="background-color: #3333CC; color: #FFFF00;">Check</td> 
    <td class="auto-style2" style="background-color: #3333CC; color: #FFFF00;">Action</td>
   
    <td class="auto-style2" style="background-color: #3333CC; color: #FFFF00;">Other</td>
   
  </tr>
        <tr  class="auto-style1">
    <td class="auto-style3">1</td>
    <td class="auto-style3">What</td> 
    <td class="auto-style10" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C1');">C1</td>
    <td class="auto-style14" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D1');">D1</td>
          <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E1');">E1</td>
    <td class="auto-style6" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F1');">F1</td> 
    <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G1');">G1</td>
    <td class="auto-style18" style="background-color: #3333CC; color: #FFFF00;"  onclick="refreshGrid('onclickTD','H1');">H1</td>
          <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I1');">I1</td>
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J1');">J1</td> 
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K1');">K1</td>
   
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L1');">L1</td>

  </tr>
        <tr class="auto-style1">
    <td class="auto-style3">2</td>
    <td class="auto-style3">Who</td>
    <td class="auto-style10" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C2');">C2</td>
          <td class="auto-style14" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D2');">D2</td>
    <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E2');">E2</td> 
    <td class="auto-style6" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F2');">F2</td>
    <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G2');">G2</td>
          <td class="auto-style18" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','H2');">H2</td>
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I2');">I2</td> 
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J2');">J2</td>
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K2');">K2</td>
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L2');">L2</td>
   
  </tr>
        <tr class="auto-style1">
    <td class="auto-style3">3</td>
    <td class="auto-style3">Where</td> 
    <td class="auto-style10" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C3');">C3</td>
    <td class="auto-style14" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D3');">D3</td>
          <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E3');">E3</td>
    <td class="auto-style6" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F3');">F3</td> 
    <td class="auto-style3" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G3');">G3</td>
    <td class="auto-style18" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','H3');">H3</td>
          <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I3');">I3</td>
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J3');">J3</td> 
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K3');">K3</td>
   
    <td class="auto-style3" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L3');">L3</td>
   
  </tr>
        <tr class="auto-style1">
    <td>4</td>
    <td>When</td> 
    <td class="auto-style8" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C4');">C4</td>
    <td class="auto-style12" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D4');">D4</td>
          <td style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E4');">E4</td>
    <td class="auto-style4" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F4');">F4</td> 
    <td style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G4');">G4</td>
    <td class="auto-style16" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','H4');">H4</td>
          <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I4');">I4</td>
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J4');">J4</td> 
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K4');">K4</td>
   
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L4');">L4</td>
   
  </tr>
        <tr class="auto-style1">
    <td>5</td>
    <td>Why</td> 
    <td class="auto-style8" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C5');">C5</td>
    <td class="auto-style12" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D5');">D5</td>
          <td style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E5');">E5</td>
    <td class="auto-style4" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F5');">F5</td> 
    <td style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G5');">G5</td>
    <td class="auto-style16" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','H5');">H5</td>
          <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I5');">I5</td>
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J5');">J5</td> 
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K5');">K5</td>
   
    <td style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L5');">L5</td>
   
  </tr>
        <tr class="auto-style1">
    <td class="auto-style1">6</td>
    <td class="auto-style1">How</td> 
    <td class="auto-style11" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','C6');">C6</td>
    <td class="auto-style15" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','D6');">D6</td>
          <td class="auto-style1" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','E6');">E6</td>
    <td class="auto-style7" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','F6');">F6</td> 
    <td class="auto-style1" style="background-color: #C6FCFD" onclick="refreshGrid('onclickTD','G6');">G6</td>
    <td class="auto-style19" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','H6');">H6</td>
          <td class="auto-style1" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','I6');">I6</td>
    <td class="auto-style1" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','J6');">J6</td> 
    <td class="auto-style1" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','K6');">K6</td>
   
    <td class="auto-style1" style="background-color: #3333CC; color: #FFFF00;" onclick="refreshGrid('onclickTD','L6');">L6</td>
   
  </tr>
</table>
                         Information: Tư duy, suy nghĩ. </br>
Action: Quyết định, hành vị </br>
Sourcce Code: Nguồn gốc </br>
Data: Dữ liệu </br>
System: hệ thống </br>
Key: kết nối </br>
Plus or less: Thay đổi </br>
Plan: Kế hoạch, mục tiêu </br>
Do: Thực hiện, làm </br>
Check: Trách nhiệm</br>
Action: Hành động</br>
Other: khác</br>
What: vật chất</br>
Who: con người</br>
Where: Địa lý</br>
When: Thời gian</br>
Why: bảo vệ, vì sao</br>
How: làm thế nào.
                     </dx:SplitterContentControl>
                 </ContentCollection>
             </dx:SplitterPane>
             <dx:SplitterPane >
                 <ContentCollection>
                        <dx:SplitterContentControl runat="server">
                            <asp:Label ID="lblDesc" runat="server" Text="" width="100%" Height="100%">

                            </asp:Label>
                        </dx:SplitterContentControl>
                </ContentCollection>
             </dx:SplitterPane>
         </Panes>
     </dx:ASPxSplitter>


 <%--<input type="button" onclick="refreshGrid();" value="Press Me" />--%>

     <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
      <script type="text/javascript">
          function __doPostBack(eventTarget, eventArgument) {
              if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                  theForm.__EVENTTARGET.value = eventTarget;
                  theForm.__EVENTARGUMENT.value = eventArgument;
                  theForm.submit();
              }
          }

          function refreshGrid(nameEvent, parameter) {
              try {

                  __doPostBack(nameEvent, parameter);

              }
              catch (err) {
                  alert(err);
              }
          }

          </script>



    </form>
</body>
</html>
