<%@ Import namespace="System.IO" %>
<%@ Import namespace="System.Runtime.Serialization.Formatters.Binary" %>

<%@ Import namespace="System.IO.Compression" %>
<%@ Import namespace="System.Globalization" %>



<%Dim DateTimeFormat As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat()%>
    
<%=DateTimeFormat.ShortDatePattern%>

<% For i As Integer =0 to 5%>
<font size="<%=i %>">Hello World!</font><br />

<% Next %>

