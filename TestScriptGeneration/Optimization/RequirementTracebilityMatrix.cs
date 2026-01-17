
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestScriptGeneration
{
    class RequirementTracebilityMatrix
    {
        RTMModel rTMModel;
        List<RTMModel> createMatrix;
        public RequirementTracebilityMatrix()
        {
            createMatrix = new List<RTMModel>();
            
            
        }
        public List<RTMModel> createRTM(TestCaseModel tests, List<DataModelforFSMModel> DM) {
            Evaluator evaluate = new Evaluator();
            string guard;
            TestCaseModel testspec = new TestCaseModel();
            testspec = tests;
            List<DataModelforFSMModel> dm = new List<DataModelforFSMModel>();
            dm = DM;

            foreach (DataModelforFSMModel data in dm) {
                rTMModel = new RTMModel();
                guard = data.guard;
                List<Testcase> testcases = new List<Testcase>(); 
                foreach (Testcase tc in tests.testcases) {
                    List<TestActions> ta = new List<TestActions>();
                    ta = tc.action;
                    bool result = evaluate.EvaluateCondition(guard, ta);
                    rTMModel.guard = guard;
                    rTMModel.requirements = data.requirements;
                    if (result) {
                        testcases.Add(tc);
                    }
                }
                rTMModel.testcases = testcases;
                createMatrix.Add(rTMModel);
            }
            return createMatrix;
        }
        //redundant code section below
        /*
        public bool Evaluate(string guardCondition, List<object> variableValues)
        {
            var parameters = new List<ParameterExpression>();
            var values = new List<object>();
            foreach (var variableValue in variableValues)
            {
                var parameter = Expression.Parameter(variableValue.GetType(), variableValue.GetType().Name);
                parameters.Add(parameter);
                values.Add(variableValue);
            }

            

            var expressionParser = new ExpressionParser(parameters.ToArray(), guardCondition, values.ToArray(), parserConfig);
            var expression = expressionParser.Parse(typeof(bool));

            var lambda = Expression.Lambda<Func<bool>>(expression);
            var result = lambda.Compile()();

            return result;
        }
        
        public bool EvaluateGuardCondition(string guardCondition, List<object> variables)
        {
            var parameterExpressions = new List<ParameterExpression>();
            var valueExpressions = new List<Expression>();
            var values = new List<object>();

            for (int i = 0; i < variables.Count; i++)
            {
                var variable = variables[i];
                var variableType = variable.GetType();
                var parameterExpression = Expression.Parameter(variableType);
                var propertyExpression = Expression.Property(parameterExpression, variableType.GetProperty("Name"));
                var valueExpression = Expression.Constant(variableType.GetProperty("Value").GetValue(variable));

                parameterExpressions.Add(parameterExpression);
                valueExpressions.Add(propertyExpression);
                values.Add(variableType.GetProperty("Value").GetValue(variable));
            }

            var expressionParser = new ExpressionParser(
                parameterExpressions.ToArray(),
                guardCondition,
                values.ToArray(),
                new ParsingConfig()
            ) ;

            var expression = expressionParser.Parse(typeof(bool));
            var lambda = Expression.Lambda<Func<object[], bool>>(expression, parameterExpressions.ToArray());
            var compiledLambda = lambda.Compile();
            var result = compiledLambda(values.ToArray());

            return result;
        }*/

        /*
        public bool EvaluateGuardCondition(string guardCondition, List<TestActions> variables)
        {
            // create a dictionary of variable names and values
            var variableValues = variables.ToDictionary(v => v.ActionVariable, v => v.ActionValue);

            // replace variable names in the guard condition with their values
            foreach (var variable in variableValues)
            {
                guardCondition = guardCondition.Replace(variable.Key, variable.Value.ToString());
            }

            // evaluate the guard condition
            //var engine = new NCalc.Expression(guardCondition);
           // return (bool)engine.Evaluate();
        } */
    }
    class Evaluator {
        public bool EvaluateCondition(string condition, List<TestActions> variables)
        {
            var parameter = Expression.Parameter(typeof(TestActions), "x");
            var valueDictionary = variables.ToDictionary(v => v.ActionVariable, v => v.ActionValue);

            // Replace the variable names with their corresponding values
            foreach (var variableName in valueDictionary.Keys)
            {
                condition = condition.Replace(variableName, valueDictionary[variableName].ToString());
            }

            // Compile the condition string into a Lambda expression
            var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, null, condition);

            // Compile the expression and evaluate it
            var compiledExpression = (Expression<Func<TestActions, bool>>)expression;
            return compiledExpression.Compile()(new TestActions());
        }
    }
}
