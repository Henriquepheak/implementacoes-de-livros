import 'package:capitulo03_splashscreen/drawer/blocs/drawer_blocs.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

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
  // bool _drawerIsOpen = false;

  double _topBody() {
    return MediaQuery.of(context).size.height - 105;
  }

  /*double _leftBody() {
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
  }*/

  void _drawerCallback(bool status) {
    if (status) {
      context.read<DrawerBloc>().add(DrawerShowPressed());
    } else {
      context.read<DrawerBloc>().add(DrawerHidePressed());
    }
  }

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
        title: const Text('Jogo da Forca'),
        centerTitle: true,
        actions: const <Widget>[
          Icon(
            Icons.menu,
            size: 40,
          ),
        ],
      ),
      topBody: _topBody(), leftBodyOpen: _leftBodyOpen(),
      leftBodyClose: _leftBodyClose(),
      //leftBody:
      //  _leftBody(), // topBody: MediaQuery.of(context).size.height - 105,
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
      callbackFunction: _drawerCallback,
    );
  }
}
