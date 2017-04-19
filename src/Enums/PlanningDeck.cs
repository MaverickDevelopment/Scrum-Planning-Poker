using System.ComponentModel.DataAnnotations;

namespace PlanningPoker.Enums
{
    public enum PlanningDeck
    {
        [Display(Description ="Fibonacci")]
        Fibonacci = 0,

        [Display(Description = "Planning Poker")]
        PlanningPoker = 1,

        [Display(Description = "Playing Cards")]
        PlayingCards = 2,

        [Display(Description = "T-Shirt Sizes")]
        TShirtSizes = 3,

        [Display(Description = "T-Shirt Sizes Extended")]
        TShirtSizesExtended = 4
    }
}
