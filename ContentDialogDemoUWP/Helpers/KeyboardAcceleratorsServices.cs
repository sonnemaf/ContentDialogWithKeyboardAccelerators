using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace ContentDialogDemoUWP.Helpers {

    /// <summary>
    ///  <ContentDialog.PrimaryButtonStyle>
    ///    <Style TargetType="Button">
    ///        <Setter Property="helpers:KeyboardAcceleratorsServices.KeyboardAccelerators">
    ///            <Setter.Value>
    ///                <helpers:KeyboardAcceleratorList>
    ///                    <KeyboardAccelerator Key="Y" />
    ///                    <KeyboardAccelerator Key="J" />
    ///                </helpers:KeyboardAcceleratorList>
    ///            </Setter.Value>
    ///        </Setter>
    ///    </Style>
    ///  </ContentDialog.PrimaryButtonStyle>
    ///  <ContentDialog.SecondaryButtonStyle>
    ///    <Style TargetType="Button">
    ///        <SetterProperty="helpers:KeyboardAcceleratorsServices.KeyboardAccelerator">
    ///            <Setter.Value>
    ///                <KeyboardAccelerator Key="N" />
    ///            </Setter.Value >
    ///        </Setter >
    ///    </Style >
    ///  </ContentDialog.SecondaryButtonStyle >
    /// </summary>
    public class KeyboardAcceleratorsServices {

        #region KeyboardAccelerator Attached Property

        /// <summary> 
        /// Identifies the KeyboardAccelerator attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty KeyboardAcceleratorProperty =
            DependencyProperty.RegisterAttached("KeyboardAccelerator",
                                                typeof(KeyboardAccelerator),
                                                typeof(KeyboardAcceleratorsServices),
                                                new PropertyMetadata(default(KeyboardAccelerator), OnKeyboardAcceleratorChanged));

        /// <summary>
        /// KeyboardAccelerator changed handler. 
        /// </summary>
        /// <param name="d">UIElement that changed its KeyboardAccelerator attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnKeyboardAcceleratorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is UIElement source) {
                if (e.NewValue is KeyboardAccelerator value) {
                    source.KeyboardAccelerators.Add(value);
                }
            }
        }

        /// <summary>
        /// Gets the value of the KeyboardAccelerator attached property from the specified FrameworkElement .
        /// </summary>
        public static KeyboardAccelerator GetKeyboardAccelerator(DependencyObject obj) {
            return (KeyboardAccelerator)obj.GetValue(KeyboardAcceleratorProperty);
        }


        /// <summary>
        /// Sets the value of the KeyboardAccelerator attached property to the specified FrameworkElement .
        /// </summary>
        /// <param name="obj">The object on which to set the KeyboardAccelerator attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetKeyboardAccelerator(DependencyObject obj, KeyboardAccelerator value) {
            obj.SetValue(KeyboardAcceleratorProperty, value);
        }

        #endregion KeyboardAccelerator Attached Property

        #region KeyboardAccelerators Attached Property

        /// <summary> 
        /// Identifies the KeyboardAccelerators attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty KeyboardAcceleratorsProperty =
            DependencyProperty.RegisterAttached("KeyboardAccelerators",
                                                typeof(IList<KeyboardAccelerator>),
                                                typeof(KeyboardAcceleratorsServices),
                                                new PropertyMetadata(default, OnKeyboardAcceleratorsChanged));

        /// <summary>
        /// KeyboardAccelerators changed handler. 
        /// </summary>
        /// <param name="d">UIElement that changed its KeyboardAccelerators attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnKeyboardAcceleratorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is UIElement source) {
                if (e.NewValue is IList<KeyboardAccelerator> value) {
                    foreach (var item in value) {
                        source.KeyboardAccelerators.Add(item);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value of the KeyboardAccelerators attached property from the specified FrameworkElement.
        /// </summary>
        public static object GetKeyboardAccelerators(DependencyObject obj) {
            return (object)obj.GetValue(KeyboardAcceleratorsProperty);
        }


        /// <summary>
        /// Sets the value of the KeyboardAccelerators attached property to the specified FrameworkElement.
        /// </summary>
        /// <param name="obj">The object on which to set the KeyboardAccelerators attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetKeyboardAccelerators(DependencyObject obj, object value) {
            obj.SetValue(KeyboardAcceleratorsProperty, value);
        }

        #endregion KeyboardAccelerators Attached Property

    }

    public class KeyboardAcceleratorList : List<KeyboardAccelerator> {
    }
}
