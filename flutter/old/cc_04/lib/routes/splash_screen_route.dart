import 'package:flutter/material.dart';
import '../widgets/circular_image_widget.dart';

class SplashScreenRoute extends StatefulWidget {
  @override
  _SplashScreenRouteState createState() => _SplashScreenRouteState();
}

class _SplashScreenRouteState extends State<SplashScreenRoute> {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        CircularImageWidget(
          imageProvider: AssetImage(
            'assets/images/splashscreen.png',
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(top: 25.0, bottom: 25),
          child: Text(
            'Aguarde....',
            style: TextStyle(
              fontSize: 40,
              fontWeight: FontWeight.bold,
            ),
          ),
        ),
        Padding(
          padding: const EdgeInsets.only(left: 100, right: 100),
          child: LinearProgressIndicator(
            backgroundColor: Colors.blue[200],
            valueColor: AlwaysStoppedAnimation<Color>(Colors.blue[900]),
          ),
        ),
      ],
    );
  }
}
