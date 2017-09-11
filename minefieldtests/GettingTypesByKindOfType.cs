using System;
using minefield.ECommerce.Pricing;
using NUnit.Framework;
using System.Linq;

namespace minefieldtests
{
    public class GettingTypesByKindOfType
    {

        [Test]
        public void ShouldReturnAllInterfaces()
        {
            // when
            var interfaces = typeof(IPricingStrategy).Assembly
                                                     .GetTypes()
                                                     .Where(t => t.IsInterface)
                                                     .ToList();

            // then
            Assert.True(interfaces.First().IsInterface);
        }

        [Test]
        public void ShouldReturnAllClasses() 
        {
            // when
            var classes = typeof(IPricingStrategy).Assembly
                                                  .GetTypes()
                                                  .Where(t => t.IsClass);

            // then
            Assert.True(classes.First().IsClass);
        }

        [Test]
        public void ShouldReturnAllEnums() 
        {
            // when
            var enums = typeof(IPricingStrategy).Assembly
                                                .GetTypes()
                                                .Where(t => t.IsEnum)
                                                .ToList();

            // then
            Assert.True(enums.First().IsEnum);
        }

        [Test]
        public void ShouldReturnAbstractTypes() {

            // when
            var abstracts = typeof(IPricingStrategy).Assembly
                                                    .GetTypes()
                                                    .Where(t => t.IsAbstract)
                                                    .ToList();

            // then
            var type = abstracts.First();

            // abstract type is either abstract class or interface
            Assert.True(
                (type.IsClass && type.IsAbstract) || 
                (type.IsInterface && type.IsAbstract));
        }

        [Test]
        public void ShouldReturnValueTypes() {

            // when
            var valueTypes = typeof(IPricingStrategy).Assembly
                                                     .GetTypes()
                                                     .Where(t => t.IsValueType)
                                                     .ToList();

            // then
            var type = valueTypes.First();

            // value types are either primitives, enums or structs
            Assert.True(
                (type.IsPrimitive) ||
                (type.IsEnum) ||
                (type.IsValueType && !type.IsEnum && !type.IsPrimitive)
            );
        }
    }
}
