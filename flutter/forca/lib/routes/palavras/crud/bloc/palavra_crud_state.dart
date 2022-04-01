part of 'palavra_crud_bloc.dart';

abstract class PalavraCRUDState extends Equatable {
  const PalavraCRUDState();

  @override
  List<Object> get props => [];
}

class PalavraModelInitialized extends PalavraCRUDState {}

class PalavraChanged extends PalavraCRUDState {
  final PalavraModel palavraModel;

  const PalavraChanged({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.palavra];
}

class AjudaChanged extends PalavraCRUDState {
  final PalavraModel palavraModel;

  const AjudaChanged({required this.palavraModel});

  @override
  List<Object> get props => [palavraModel.ajuda];
}

class FormIsValidated extends PalavraCRUDState {
  final PalavraModel palavraModel;

  const FormIsValidated({required this.palavraModel});

  @override
  List<Object> get props => [
        palavraModel.palavraID,
        palavraModel.palavra,
        palavraModel.ajuda,
      ];
}
