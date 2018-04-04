
<%@ page import="java.util.Iterator" %>
<jsp:useBean id="spingcart" class="SPCart.Cart" scope="session"/>

<html>

<head>
  <title>Session Example 2</title>
  <style type="text/css">
    td { text-align:center }
  </style>
</head>

<body>

<h1>Session Example 3</h1>

<%-- Access a (new) shopping cart --%>

  <%
    //HttpSession session = request.getSession();
   // Cart cart = (Cart)session.getAttribute("cart");
   // if (cart == null) cart = new Cart();

  %>

<%-- If parameters are given, then add the item to the cart --%>

  <%
    String id = request.getParameter("id");
    String quantity = request.getParameter("quantity");
    if (id != null && quantity != null)
    {
      spingcart.addItem(id, (new Integer(quantity)).intValue());
    //  session.setAttribute("cart", cart);
  %>
      <h2>Congradulations on a Successful Purchase</h2>

      <p>
        Item: <%= id %>, Quantity: <%= quantity %>.
      </p>

      <hr />

  <%
    }
  %>

<%-- Report on the status of the cart --%>

  <h2>Items in your Shopping Cart</h2>

  <%
    if (spingcart.isEmpty()) {
  %>
      <p>Your shopping cart is currently empty.</p>
  <%
    } else {
  %>
      <table>
        <tr><th>Item</th><th>Quantity</th></tr>
    <%
      Iterator idIter = spingcart.getIds();
      while (idIter.hasNext()) {
        String itemId = (String)idIter.next();
    %>
        <tr><td><%= itemId %></td><td><%= spingcart.getQuantity(itemId)
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

    <form method="get" action="session3.jsp">

      <p>
        Please select an item and quantity.
      </p>

      <div>
        Item:
        <select name="id" size="1">
          <option>Ford Laser TX3</options>
          <option>Maserati Spyder</options>
          <option>Mazda RX7 Series 6</options>
          <option>Nissan Skyline GT4</options>
          <option>Porsche 993</options>
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

