﻿using System;

namespace prep.utility.searching
{
  public static class MatchCreationExtensions
  {
    public static IMatchA<Target> equal_to<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, PropertyType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchA<Target> create_from_condition<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, Criteria<Target> condition)
    {
      return new AnonymousMatch<Target>(condition);
    }

    public static IMatchA<Target> equal_to_any<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, params PropertyType[] values)
    {
      return create_from_attribute_criteria(extension_point, new IsEqualToAny<PropertyType>(values));
    }

    public static IMatchA<Target> create_from_attribute_criteria<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, IMatchA<PropertyType> condition)
    {
      return new AttributeMatch<Target, PropertyType>(extension_point.accessor, condition);
    }

    public static IMatchA<Target> not_equal_to<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, PropertyType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchA<Target> greater_than<Target, PropertyType>(this MatchCreationExtensionPoint<Target, PropertyType> extension_point, PropertyType comparison_value)
     where PropertyType : IComparable<PropertyType>
    {
        return create_from_attribute_criteria(extension_point, new IsGreaterThan<PropertyType>(comparison_value));
    }

    public static IMatchA<Target> between<Target,PropertyType>(this MatchCreationExtensionPoint<Target,PropertyType> extension_point, PropertyType start, PropertyType end) 
      where PropertyType : IComparable<PropertyType>
    {
      return create_from_attribute_criteria(extension_point, new IsBetween<PropertyType>(start, end));
    }
  }

    public static class MatchCreationSepcificExtensions
    {
        public static IMatchA<Target> greater_than<Target>(this MatchCreationExtensionPoint<Target, DateTime> extension_point, int comparison_value)
        {
            return extension_point.create_from_attribute_criteria(new IsGreaterThan<DateTime>(new DateTime(comparison_value, 12, 31)));
        }

    }
}
