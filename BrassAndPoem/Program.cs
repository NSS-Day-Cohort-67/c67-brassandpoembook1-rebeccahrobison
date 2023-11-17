
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "French Horn",
        Price = 5000.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Flugelhorn",
        Price = 1200.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Alphorn",
        Price = 7000.00M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "'A Thousand Mornings' by Mary Oliver",
        Price = 19.00M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "'I Know Why the Caged Bird Sings' by Maya Angelou",
        Price = 25.00M,
        ProductTypeId = 2
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass Instrument",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poetry Book",
        Id = 2
    }
};
//put your greeting here
string greeting = @"Welcome to Brass & Poem:
                    A Shop for Brass Instrument and Poetry Lovers";
Console.WriteLine(greeting);

//implement your loop here
string userChoice = null;
while (userChoice != "5")
{
    DisplayMenu();
    userChoice = Console.ReadLine();
    switch (userChoice)
    {
      case "1":
        DisplayAllProducts(products, productTypes);
        break;
      case "2":
        DeleteProduct(products, productTypes);
        break;
      case "3":
        AddProduct(products, productTypes);
        break;
      case "4":
        UpdateProduct(products, productTypes);
        break;
      case "5":
        Console.WriteLine("Goodbye from Brass and Poem! <3");
        break;
      default:
        Console.WriteLine(greeting);
        break;
    }

}

void DisplayMenu()
{
    Console.WriteLine(@"Choose an option:
                        1. Display all products
                        2. Delete a product
                        3. Add a new product
                        4. Update product properties
                        5. Exit");
};

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
  Console.WriteLine("Products:");
  foreach (Product product in products)
  {
    Console.WriteLine($"{products.IndexOf(product) + 1}. {ProductDetails(product)}");
  }
}

void DisplayAllProductTypes()
{
  Console.WriteLine("Product Types:");
  foreach(ProductType productType in productTypes)
  {
    Console.WriteLine($"{productTypes.IndexOf(productType) + 1}. {productType.Title}");
  }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
  Console.WriteLine("Type the number of the product you would like to delete:");
  DisplayAllProducts(products, productTypes);
  int userInput = int.Parse(Console.ReadLine());
  Product productToDelete = products.FirstOrDefault(p => userInput == products.IndexOf(p) + 1);
  if(productToDelete != null)
  {
    products.Remove(productToDelete);
  }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please enter the details of the product to be added.");
    Console.WriteLine("What's the name of the product?");
    string nameOfProductToAdd = Console.ReadLine();
    Console.WriteLine("What's the price of the product?");
    decimal priceOfProductToAdd = decimal.Parse(Console.ReadLine());
    Console.WriteLine("What's the product Id number?");
    DisplayAllProductTypes();
    int productTypeOfProductToAdd = int.Parse(Console.ReadLine());

    Product productToAdd = new Product()
    {
      Name = nameOfProductToAdd,
      Price = priceOfProductToAdd,
      ProductTypeId = productTypeOfProductToAdd
    };
    products.Add(productToAdd);
    Console.WriteLine($"Your {nameOfProductToAdd} has successfully been added.");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
  Console.WriteLine("Type the number of the product to be updated:");
  DisplayAllProducts(products, productTypes);
  int userInput = int.Parse(Console.ReadLine());

  Product chosenProduct = null;
  int chosenProductIndex = 0;

  Product foundProduct = products.FirstOrDefault(p => userInput == products.IndexOf(p) + 1);
  if (foundProduct != null)
  {
    chosenProduct = foundProduct;
    chosenProductIndex = products.IndexOf(foundProduct);
  }

  Console.WriteLine($"Update the product name '{chosenProduct.Name}', or press 'Enter' to keep the same.");
  string updatedName = Console.ReadLine();
  if(updatedName != "")
  {
    
    products[chosenProductIndex].Name = updatedName;
  }
  Console.WriteLine(products[chosenProductIndex].Name);

  Console.WriteLine($"Update the product price '{chosenProduct.Price}', or press 'Enter' to keep the same.");
  string updatedPrice = Console.ReadLine();
  if (updatedPrice != "")
  {
    decimal priceStringToDecimal = decimal.Parse(updatedPrice);
    products[chosenProductIndex].Price = priceStringToDecimal;
  }
  Console.WriteLine(products[chosenProductIndex].Price);

  Console.WriteLine($"Update the product type '{chosenProduct.ProductTypeId}' of the product, or press 'Enter' to keep the same.");
  DisplayAllProductTypes();
  string updatedProductTypeId = Console.ReadLine();
  if (updatedProductTypeId != "")
  {
    int idStringToInt = int.Parse(updatedProductTypeId);
    products[chosenProductIndex].ProductTypeId = idStringToInt;
  }
  Console.WriteLine(products[chosenProductIndex].ProductTypeId);

  Console.WriteLine($"You've updated your product to: {ProductDetails(products[chosenProductIndex])}");

}

string ProductDetails(Product product)
{
  string currentProductType = productTypes
    .Where(productType => productType.Id == product.ProductTypeId)
    .Select(productType => productType.Title)
    .FirstOrDefault() ?? "";
  string productString = $"{product.Name} ({currentProductType}) ${product.Price}";
  return productString;
}

// don't move or change this!
public partial class Program { }