import 'package:cc04/drawer/widgets/drawerbody_app.dart';
import 'package:cc04/drawer/widgets/drawerbodycontent_app.dart';
import 'package:cc04/drawer/widgets/drawerheader_app.dart';
import 'package:cc04/widgets/circular_image_widget.dart';
import 'package:flutter/material.dart';
import 'package:cc04/drawer/widgets/drawer_controller_widget.dart';

class DrawerRoute extends StatefulWidget {
  @override
  _DrawerRouteState createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  bool _drawerIsOpen = false;

  double _topBody() {
    return MediaQuery.of(context).size.height - 105;
  }

//  double _leftBody() {
//    if (!_drawerIsOpen)
//      return MediaQuery.of(context).size.width - 105;
//    else
//      return 5;
//  }

//  _handleDrawer(bool drawerIsOpen) {
//    setState(() {
//      this._drawerIsOpen = drawerIsOpen;
//    });
//  }

  double _leftBodyOpen() {
    return 5;
  }

  double _leftBodyClose() {
    return MediaQuery.of(context).size.width - 105;
  }

  @override
  Widget build(BuildContext context) {
    return DrawerControllerWidget(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        title: Text('Jogo da Forca'),
        centerTitle: true,
        actions: <Widget>[
          Icon(
            Icons.menu,
            size: 40,
          ),
        ],
      ),
      topBody: _topBody(),
//      leftBody: _leftBody(),
      body: CircularImageWidget(
        imageProvider: AssetImage('assets/images/splashscreen.png'),
        width: 100,
        heigth: 100,
      ),
      drawer: Drawer(
        child: Column(
          children: <Widget>[
            DrawerHeaderApp(),
            DrawerBodyApp(
              child: DrawerBodyContentApp(),
            ),
          ],
        ),
      ),
//      callbackFunction: _handleDrawer,
      leftBodyOpen: _leftBodyOpen(),
      leftBodyClose: _leftBodyClose(),
    );
  }
}
