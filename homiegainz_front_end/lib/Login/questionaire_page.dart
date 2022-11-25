import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import '../../util/globals.dart' as globals;
import '../../util/requests.dart';
import 'package:survey_kit/survey_kit.dart';

class QuestionnairePage extends StatefulWidget {
  const QuestionnairePage({Key? key}) : super(key: key);

  @override
  State<QuestionnairePage> createState() => _QuestionnairePageState();
}

class _QuestionnairePageState extends State<QuestionnairePage> {
  @override
  Widget build(BuildContext context) {
    
    Requests requests = Requests();
    
    return Scaffold(
        body: Container(
            color: Colors.black,
            child: Align(
                alignment: Alignment.center,
                child: SurveyKit(
                  onResult: (SurveyResult result) {
                    print(result.finishReason);
                    int score = 0;
                    for (var stepResult in result.results) {
                      for (var questionResult in stepResult.results) {
                        score += int.tryParse(questionResult.valueIdentifier ?? "0") ?? 0;
                      }
                    }
                    print("final Score is $score");
                    requests
                        .makeGetRequestWithAuth("http://10.0.2.2:9000/users/questionaireTotal/${globals.userID}/$score", globals.username, globals.password)
                    .then((value) {
                      print(json.decode(value));
                      globals.workoutPlanID = json.decode(value)["workoutPlan"]["id"];
                      print(globals.workoutPlanID);
                      globals.mealPlanID = json.decode(value)["mealPlan"]["id"];
                      print(globals.mealPlanID);
                    });
                    Navigator.pushNamed(context, '/');
                  },
                  task: getSampleTask(),
                  showProgress: true,
                  localizations: const {
                    'next': 'Next',
                  },
                  themeData: Theme.of(context).copyWith(
                    colorScheme: ColorScheme.fromSwatch(
                      primarySwatch: Colors.blue,
                    ).copyWith(
                      onPrimary: Colors.white,
                    ),
                    primaryColor: Colors.blue,
                    backgroundColor: Colors.white12,
                    appBarTheme: const AppBarTheme(
                      color: Colors.white12,
                      iconTheme: IconThemeData(
                        color: Colors.blue,
                      ),
                      titleTextStyle: TextStyle(
                        color: Colors.blue,
                      ),
                    ),
                    iconTheme: const IconThemeData(
                      color: Colors.blue,
                    ),
                    textSelectionTheme: const TextSelectionThemeData(
                      cursorColor: Colors.blue,
                      selectionColor: Colors.blue,
                      selectionHandleColor: Colors.blue,
                    ),
                    cupertinoOverrideTheme: const CupertinoThemeData(
                      primaryColor: Colors.blue,
                    ),
                    outlinedButtonTheme: OutlinedButtonThemeData(
                      style: ButtonStyle(
                        minimumSize: MaterialStateProperty.all(
                          const Size(150.0, 60.0),
                        ),
                        side: MaterialStateProperty.resolveWith(
                          (Set<MaterialState> state) {
                            if (state.contains(MaterialState.disabled)) {
                              return const BorderSide(
                                color: Colors.white12,
                              );
                            }
                            return const BorderSide(
                              color: Colors.blue,
                            );
                          },
                        ),
                        shape: MaterialStateProperty.all(
                          RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                        ),
                        textStyle: MaterialStateProperty.resolveWith(
                          (Set<MaterialState> state) {
                            if (state.contains(MaterialState.disabled)) {
                              return Theme.of(context)
                                  .textTheme
                                  .button
                                  ?.copyWith(
                                    color: Colors.white12,
                                  );
                            }
                            return Theme.of(context).textTheme.button?.copyWith(
                                  color: Colors.blue,
                                );
                          },
                        ),
                      ),
                    ),
                    textButtonTheme: TextButtonThemeData(
                      style: ButtonStyle(
                        textStyle: MaterialStateProperty.all(
                          Theme.of(context).textTheme.button?.copyWith(
                                color: Colors.blue,
                              ),
                        ),
                      ),
                    ),
                    textTheme: const TextTheme(
                      headline2: TextStyle(
                        fontSize: 28.0,
                        color: Colors.white,
                      ),
                      headline5: TextStyle(
                        fontSize: 24.0,
                        color: Colors.white,
                      ),
                      bodyText2: TextStyle(
                        fontSize: 18.0,
                        color: Colors.white,
                      ),
                      subtitle1: TextStyle(
                        fontSize: 18.0,
                        color: Colors.white,
                      ),
                    ),
                    inputDecorationTheme: const InputDecorationTheme(
                      labelStyle: TextStyle(
                        color: Colors.white,
                      ),
                    ),
                  ),
                  surveyProgressbarConfiguration: SurveyProgressConfiguration(
                    backgroundColor: Colors.white,
                  ),
                ))));
  }

  Task getSampleTask() {
    var task = NavigableTask(
      id: TaskIdentifier(),
      steps: [
        InstructionStep(
          title: 'Welcome to the\nHomieGainz\nQuestionnaire',
          text: 'We need to ask some questions in order to create a workout plan and a meal plan for you!',
          buttonText: 'Let\'s do it!',
        ),
        QuestionStep(
          title: 'Body Preference',
          text: 'What do you want to do with your body?',
          isOptional: false,
          answerFormat: const SingleChoiceAnswerFormat(
            textChoices: [
              TextChoice(text: 'Slim Down', value: '0'),
              TextChoice(text: 'Cut', value: '1'),
              TextChoice(text: 'Tune Up', value: '2'),
              TextChoice(text: 'Bulk Up', value: '3'),
            ],
          ),
        ),
        QuestionStep(
          title: 'Food Preference',
          text: 'How many calories do you eat a day',
          isOptional: false,
          answerFormat: const SingleChoiceAnswerFormat(
            textChoices: [
              TextChoice(text: '1500-2000', value: '1'),
              TextChoice(text: '2000-2500', value: '2'),
              TextChoice(text: '2500+', value: '3'),
            ],
          ),
        ),
        QuestionStep(
          title: 'Have you ever worked out for more than a month?',
          text: 'This is to know where to start for your workout plan :)',
          isOptional: false,
          answerFormat: const SingleChoiceAnswerFormat(
            textChoices: [
              TextChoice(text: 'Yes', value: '2'),
              TextChoice(text: 'No', value: '1'),
            ],
            defaultSelection: TextChoice(text: 'No', value: '1'),
          ),
        ),
        QuestionStep(
          title: 'Ideal Weight',
          text: 'What is the ideal weight that you would want?',
          isOptional: false,
          answerFormat: const SingleChoiceAnswerFormat(
            textChoices: [
              TextChoice(text: '150 lbs', value: '0'),
              TextChoice(text: '200 lbs', value: '1'),
              TextChoice(text: '250+ lbs', value: '2'),
            ],
          ),
        ),
        CompletionStep(
          stepIdentifier: StepIdentifier(id: '321'),
          text: 'Thanks for taking the questionnaire, we found the perfect plan for you!',
          title: 'Done!',
          buttonText: 'Submit Questionnaire',
        ),
      ],
    );
    return task;
  }
}
