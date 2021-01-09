using System;

namespace Viscosity_WPF
{
   

    public class ViscosityCalc
    {   
          public static double ViscosityTranslate(visKUnit firstUnit, double firstValue, visKUnit secUnit)
          {
              return SecondCalculation(secUnit, NormaliseValueToStokses(firstUnit, firstValue));
          }

          private static double NormaliseValueToStokses(visKUnit fUnit, double fValue)
          {
              double result = 0.0;

              switch (fUnit)
              {
                  case visKUnit.St:
                      result = fValue;
                      break;
                  case visKUnit.sSt:
                      result = fValue / 100;
                      break;
                  case visKUnit.m2sec:
                      result = fValue / 0.0001;
                      break;
                  case visKUnit.mm2sec:
                      result = fValue / 100;
                      break;
                  case visKUnit.inch2sec:
                      result = fValue / 558;
                      break;
                  case visKUnit.ft2sec:
                      result = fValue / 3.88;
                      break;
              }

              return result;
          }
          private static double SecondCalculation(visKUnit Coeff2, double Volue2)
          {

              double result = 0.0;

              switch (Coeff2)
              {
                  case visKUnit.St:
                      result = Volue2;
                      break;
                  case visKUnit.sSt:
                      result = Volue2 * 100;
                      break;
                  case visKUnit.m2sec:
                      result = Volue2 * 0.0001;
                      break;
                  case visKUnit.mm2sec:
                      result = Volue2 * 100;
                      break;
                  case visKUnit.inch2sec:
                      result = Volue2 * 558;
                      break;
                  case visKUnit.ft2sec:
                      result = Volue2 * 3.88;
                      break;
              }

              return result;
          }
       
    }
}
