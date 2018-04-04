<%@ page import="SPCart.*" %>
<%@ page import="java.util.Iterator" %>

<html>

<head>
  <title>Session Example</title>
  <style type="text/css">
    td { text-align:center }
  </style>
</head>

<body>

<h1>Session Example</h1>

<%-- Access a (new) shopping cart --%>

  <%
    //HttpSession session = request.getSession();
    SPCart.Cart mycart = (SPCart.Cart)session.getAttribute("cart");
    if (mycart == null) mycart = new SPCart.Cart();
  %>

<%-- If parameters are given, then add the item to the cart --%>

  <%
    String id = request.getParameter("id");
    String quantity = request.getParameter("quantity");
    if (id != null && quantity != null)
    {
      mycart.addItem(id, (new Integer(quantity)).intValue());
      session.setAttribute("cart", mycart);
  %>
      <h2>Congradulations on a Successful Purchase</h2>

      <p>
        Item: <%= id %>, Quantity: <%= quantity %>.
      </p>

      <hr />

  <%
      id = null; quantity = null;
    }
  %>

<%-- Report on the status of the cart --%>

  <h2>Items in your Shopping Cart</h2>

  <%
    if (mycart.isEmpty()) {
  %>
      <p>Your shopping cart is currently empty.</p>
  <%
    } else {
  %>
      <table>
        <tr><th>Item</th><th>Quantity</th></tr>
    <%
      Iterator idIter = mycart.getIds();
      while (idIter.hasNext()) {
        String itemId = (String)idIter.next();
    %>
        <tr><td><%= itemId %></td><td><%= mycart.getQuantity(itemId) 
%></td></tr>
    <%
      }
    %>
       </table>
  <%
     }
  %>

  <hr />

<%-- Let the user purchase more items --%>

  <h2>Purchase some items</h2>

    <form method="get" action="session1.jsp">

      <p>
        Please select an item and quantity.
      </p>

      <div>
        Item:
        <select name="id" size="1">
          <option>Jelly Babies</options>
          <option>Snakes</options>
          <option>Chocolate Frogs</options>
          <option>Strawberry Frogs</options>
          <option>Caramel Frogs</options>
        </select>
      </div>

      <div>
        Quantity:
        <input type="text" name="quantity" size="3" />
      </div>

      <div>
        <input type="submit" value="Purchase!" />
        <input type="reset" value="Reset Form" />
      </div>

    </form>

</body>

</html>
