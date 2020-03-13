﻿/*********************************************************************************
* The MIT License(MIT)                                                           *
*                                                                                *
* Copyright(c) Open Source Software Initiative Contributors                      *
*                                                                                *
* Permission is hereby granted, free of charge, to any person obtaining a copy   *
* of this software and associated documentation files (the "Software"), to deal  *
* in the Software without restriction, including without limitation the rights   *
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell      *
* copies of the Software, and to permit persons to whom the Software is          *
* furnished to do so, subject to the following conditions:                       *
*                                                                                *
* The above copyright notice and this permission notice shall be included in all *
* copies or substantial portions of the Software.                                *
*                                                                                *
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR     *
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,       *
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE    *
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER         *
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,  *
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE  *
* SOFTWARE.                                                                      *
*********************************************************************************/


namespace NetStandard.Utilities.Serialization.Xml
{
    /// <summary>
    /// Provides a simple API for configuring the constructor of the entity type in the XML model.
    /// A specific entity can be deserialized using an user defined constructor.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity that belongs to XML model.</typeparam>
    public sealed class XmlConstructorTypeBuilder<TEntity>
    {
        private readonly XmlEntityTypeInfo _xmlEntityTypeInfo;
        private readonly XmlModelBuilder _xmlModelTypeBuilder;
        private readonly XmlModelTypeInfo _xmlModelTypeInfo;

        internal XmlConstructorTypeBuilder(XmlEntityTypeInfo xmlEntityTypeInfo, XmlModelTypeInfo xmlModelTypeInfo, XmlModelBuilder xmlModelTypeBuilder)
        {
            _xmlEntityTypeInfo = xmlEntityTypeInfo;
            _xmlModelTypeBuilder = xmlModelTypeBuilder;
            _xmlModelTypeInfo = xmlModelTypeInfo;
        }

        /// <summary>
        /// Excludes the constructor from XML model.
        /// </summary>
        /// <returns><see cref="XmlModelBuilder"/></returns>
        public XmlModelBuilder Ignore()
        {
            _xmlEntityTypeInfo.ConstructorParametersTypeInfo.Clear();
            return _xmlModelTypeBuilder;
        }


        /// <summary>
        /// Returns an object that can be used to configure the constructor parameter of the entity type.
        /// A specific entity can be deserialized using an user defined constructor.
        /// If the specified constructor parameter is not already part of the model, it will be added. 
        /// </summary>
        /// <param name="parameterIndex"></param>
        /// <returns><see cref="XmlConstructorParameterTypeBuilder{TEntity}"/></returns>
        public XmlConstructorParameterTypeBuilder<TEntity> Parameter(int parameterIndex)
        {
            XmlConstructorParameterTypeInfo constructorParameterTypeInfo = _xmlEntityTypeInfo.GetOrCreateConstructorParameterTypeInfo(parameterIndex);
            return new XmlConstructorParameterTypeBuilder<TEntity>(_xmlEntityTypeInfo, constructorParameterTypeInfo, _xmlModelTypeInfo, _xmlModelTypeBuilder);
        }
    }
}