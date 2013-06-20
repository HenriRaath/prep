using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using prep.utility.searching;

namespace prep.specs
{
    class OrMatchSpecs
    {
        public abstract class concern : Observes<OrMatch<int>>
        {
        }

        public class when_OR_matching : concern
        {
            private Establish c = () =>
                {
                    iMatchA1 = depends.on<IMatchA<int>>();
                    iMatchA2 = depends.on<IMatchA<int>>();

                    iMatchA1.setup(x => x.matches(1)).Return(true);
                    iMatchA2.setup(x => x.matches(2)).Return(true);
                };

            private class and_neither_matches
            {
                
                private Because b = () =>
                                result = sut.matches(0);
            
                It should_return_false = () =>
                    result.ShouldBeFalse();
            }

            private class and_first_matches
            {
                private Because b = () =>
                                    result = sut.matches(1);

                It should_return_true = () =>
                    result.ShouldBeTrue();
            }

            private class and_second_matches
            {
                private Because b = () =>
                                    result = sut.matches(2);

                It should_return_true = () =>
                    result.ShouldBeTrue();
            }

            private static IMatchA<int> iMatchA1;
            private static IMatchA<int> iMatchA2;
            private static bool result;
        }

    }
}
