using AutoFixture;
using AutoFixture.Kernel;

namespace Benchmarking.Fakers.SpecimenBuilders
{
    public class UtcRandomDateTimeSequenceGenerator : ISpecimenBuilder
    {
        protected ISpecimenBuilder InnerRandomDateTimeSequenceGenerator { get; }

        internal UtcRandomDateTimeSequenceGenerator()
        {
            InnerRandomDateTimeSequenceGenerator = new RandomDateTimeSequenceGenerator();
        }

        public object Create(object request, ISpecimenContext context)
        {
            object rawResult;
            object returnValue;

            rawResult = InnerRandomDateTimeSequenceGenerator.Create(request, context);
            if (rawResult is NoSpecimen)
            {
                returnValue = rawResult;
            }
            else
            {
                returnValue = ((DateTime)rawResult).ToUniversalTime();
            }

            return returnValue;
        }
    }
}
