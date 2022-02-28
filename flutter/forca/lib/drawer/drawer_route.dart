import 'package:flutter/material.dart';

import '../widgets/circular_image_widget.dart';
import 'widgets/drawer_controller_widget.dart';
import 'widgets/drawerbody_app.dart';
import 'widgets/drawerbodycontent_app.dart';
import 'widgets/drawerheader_app.dart';

class DrawerRoute extends StatefulWidget {
  const DrawerRoute({Key? key}) : super(key: key);

  @override
  State<DrawerRoute> createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  bool _drawerIsOpen = false;

  double _topBody() {
    return MediaQuery.of(context).size.height - 105;
  }

  double _leftBody() {
    if (!_drawerIsOpen) {
      return MediaQuery.of(context).size.width - 105;
    } else {
      return 5;
    }
  }

  _handleDrawer(bool drawerIsOpen) {
    setState(() {
      _drawerIsOpen = drawerIsOpen;
    });
  }

  @override
  Widget build(BuildContext context) {
    return DrawerControllerWidget(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        title: const Text('Jogo da Forca'),
        centerTitle: true,
        actions: const <Widget>[
          Icon(
            Icons.menu,
            size: 40,
          ),
        ],
      ),
      topBody: _topBody(),
      leftBody:
          _leftBody(), // topBody: MediaQuery.of(context).size.height - 105,
      // leftBody: MediaQuery.of(context).size.width - 105,
      body: const CircularImageWidget(
        imageProvider: AssetImage('assets/images/splashscreen.png'),
        width: 100,
        height: 100,
      ),
      drawer: Drawer(
        child: Column(
          children: const <Widget>[
            DrawerHeaderApp(),
            DrawerBodyApp(
              child: DrawerBodyContentApp(),
            ),
          ],
        ),
      ),
      callbackFunction: _handleDrawer,
    );
  }
}
