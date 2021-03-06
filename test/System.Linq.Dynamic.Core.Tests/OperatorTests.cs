﻿using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Dynamic.Core.Tests.Helpers.Models;
using Xunit;

namespace System.Linq.Dynamic.Core.Tests
{
    public class OperatorTests
    {
        [Fact]
        public void Operator_Multiplication_Single_Float_ParseException()
        {
            //Arrange
            var models = new[] { new SimpleValuesModel() }.AsQueryable();

            //Act + Assert
            Assert.Throws<ParseException>(() => models.Select("FloatValue * DecimalValue"));
        }

        [Fact]
        public void Operator_Multiplication_Single_Float_Cast()
        {
            //Arrange
            var models = new SimpleValuesModel[] { new SimpleValuesModel() { FloatValue = 2, DecimalValue = 3 } }.AsQueryable();

            //Act
            var result = models.Select("Decimal(FloatValue) * DecimalValue").First();

            //Assert
            Assert.Equal(6.0m, result);
        }
    }
}