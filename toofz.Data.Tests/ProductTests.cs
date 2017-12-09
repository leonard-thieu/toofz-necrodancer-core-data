using System;
using Xunit;

namespace toofz.Data.Tests.Leaderboards
{
    public class ProductTests
    {
        public class Constructor
        {
            [DisplayFact("Name", nameof(ArgumentNullException))]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var productId = 1;
                string name = null;
                var displayName = "myDisplayName";

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Product(productId, name, displayName);
                });
            }

            [DisplayFact("DisplayName", nameof(ArgumentNullException))]
            public void DisplayNameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var productId = 1;
                var name = "myName";
                string displayName = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Product(productId, name, displayName);
                });
            }

            [DisplayFact(nameof(Product))]
            public void ReturnsProduct()
            {
                // Arrange
                var productId = 1;
                var name = "myName";
                var displayName = "myDisplayName";

                // Act
                var product = new Product(productId, name, displayName);

                // Assert
                Assert.IsAssignableFrom<Product>(product);
            }

            [DisplayFact(nameof(Product.ProductId))]
            public void SetsProductId()
            {
                // Arrange
                var productId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var product = new Product(productId, name, displayName);

                // Act
                var productId2 = product.ProductId;

                // Assert
                Assert.Equal(productId, productId2);
            }

            [DisplayFact(nameof(Product.Name))]
            public void SetsName()
            {
                // Arrange
                var productId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var product = new Product(productId, name, displayName);

                // Act
                var name2 = product.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [DisplayFact(nameof(Product.DisplayName))]
            public void SetsDisplayName()
            {
                // Arrange
                var productId = 1;
                var name = "myName";
                var displayName = "myDisplayName";
                var product = new Product(productId, name, displayName);

                // Act
                var displayName2 = product.DisplayName;

                // Assert
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
