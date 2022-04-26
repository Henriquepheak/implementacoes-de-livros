import 'package:flutter/material.dart';

class TextButtonWithSnackbarWidget extends StatelessWidget {
  final bool onPressedVisible;
  final String buttonText;
  final String textToSnackBar;
  final Function onButtonPressed;
  final Function onStackBarClosed;

  const TextButtonWithSnackbarWidget({
    Key? key,
    required this.onPressedVisible,
    required this.buttonText,
    required this.textToSnackBar,
    required this.onButtonPressed,
    required this.onStackBarClosed,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextButton(
      child: Text(buttonText),
      onPressed: onPressedVisible
          ? () async {
              FocusScope.of(context).unfocus();
              onButtonPressed();

              ScaffoldMessenger.of(context)
                  .showSnackBar(
                    SnackBar(
                      backgroundColor: Colors.indigo,
                      content: Text(
                        textToSnackBar,
                        textAlign: TextAlign.center,
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      duration: const Duration(seconds: 3),
                    ),
                  )
                  .closed
                  .then((_) => onStackBarClosed());
            }
          : null,
    );
  }
}
