using System.Windows;
using System.Windows.Controls.Primitives;
using HomeWork.Models;
using Microsoft.Xaml.Behaviors;

namespace HomeWork.Behaviors
{
    public sealed class AllowSelectionDirectionBehavior : Behavior<Selector>
    {
        public Direction AllowedDirection { get; set; }

        public Direction CurrentDirection
        {
            get { return (Direction)GetValue(CurrentDirectionProperty); }
            set { SetValue(CurrentDirectionProperty, value); }
        }

        public static readonly DependencyProperty CurrentDirectionProperty =
            DependencyProperty.Register(nameof(CurrentDirection), typeof(Direction), typeof(AllowSelectionDirectionBehavior), new PropertyMetadata(Direction.LeftToRight));


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CurrentDirection != AllowedDirection)
            {
                AssociatedObject.SelectedIndex = -1;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }
    }
}
