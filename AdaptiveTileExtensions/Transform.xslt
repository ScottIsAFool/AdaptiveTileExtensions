<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns:ace="https://github.com/ScottIsAFool/AdaptiveTileExtensions" exclude-result-prefixes="msxsl ace i">
    <xsl:output method="xml" indent="yes"/>

    <xsl:variable name="smallcase" select="'abcdefghijklmnopqrstuvwxyz'" />
    <xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'" />
    
    <xsl:template match="ace:Tile">
        <tile version="{ace:Version/text()}">
            <visual>
                <xsl:apply-templates select="ace:Bindings/ace:TileBinding" />
            </visual>
        </tile>
    </xsl:template>

    <xsl:template match="ace:TileBinding">
        <binding template="{ace:TemplateType/text()}">
            <xsl:if test="ace:DisplayName">
                <xsl:attribute name="displayName">
                    <xsl:value-of select="ace:DisplayName/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:Branding">
                <xsl:attribute name="branding">
                    <xsl:value-of select="ace:Branding/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:TextStacking">
                <xsl:attribute name="hint-textStacking">
                    <xsl:value-of select="ace:TextStacking/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:OverlayOpacity">
                <xsl:attribute name="hint-overlay">
                    <xsl:value-of select="ace:OverlayOpacity/text()" />
                </xsl:attribute>
            </xsl:if>

            <xsl:apply-templates select="ace:Items/ace:Item"  />
        </binding>
    </xsl:template>

    <xsl:template match="ace:Item[@i:type='TileImage']">
        <image src="{ace:Source/text()}" placement="{ace:Placement/text()}">
            <xsl:if test="ace:RemoveMargin">
                <xsl:attribute name="hint-removeMargin">
                    <xsl:value-of select="ace:RemoveMargin/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:ImageAlignment">
                <xsl:attribute name="hint-align">
                    <xsl:value-of select="ace:ImageAlignment/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:ImageCropping">
                <xsl:attribute name="hint-crop">
                    <xsl:value-of select="ace:ImageCropping/text()" />
                </xsl:attribute>
            </xsl:if>
        </image>
    </xsl:template>
    
    <xsl:template match="ace:Item[@i:type='Group']">
        <group>
            <xsl:apply-templates select="ace:Children/ace:Item" />
        </group>
    </xsl:template>

    <xsl:template match="ace:Item[@i:type='SubGroup']">
        <subgroup>
            <xsl:if test="ace:Width">
                <xsl:attribute name="hint-weight">
                    <xsl:value-of select="ace:Width/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:TextStacking">
                <xsl:attribute name="hint-textStacking">
                    <xsl:value-of select="ace:TextStacking/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates select="ace:Children/ace:Item" />
        </subgroup>
    </xsl:template>

    <xsl:template match="ace:Item[@i:type='Text']">
        <text>
            <xsl:if test="ace:Style">
                <xsl:attribute name="hint-style">
                    <xsl:choose>
                        <xsl:when test="ace:IsSubtleStyle and boolean( ace:IsSubtleStyle/text() )">
                            <xsl:value-of select="concat( translate(ace:Style/text(), $uppercase, $smallcase), 'Subtle' )" />
                        </xsl:when>
                        <xsl:when test="ace:IsNumeralStyle and boolean( ace:IsNumeralStyle/text() )">
                            <xsl:value-of select="concat( translate(ace:Style/text(), $uppercase, $smallcase), 'Numeral' )" />
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="translate(ace:Style/text(), $uppercase, $smallcase)" />
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:Alignment">
                <xsl:attribute name="hint-align">
                    <xsl:value-of select="ace:Alignment/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:WrapText">
                <xsl:attribute name="hint-wrap">
                    <xsl:value-of select="ace:WrapText/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="ace:MaxLines">
                <xsl:attribute name="hint-maxLines">
                    <xsl:value-of select="ace:MaxLines/text()" />
                </xsl:attribute>
            </xsl:if>
            <xsl:value-of select="ace:Content/text()" />
        </text>
    </xsl:template>

    <!-- Noop: -->
    <xsl:template match="text()" />
</xsl:stylesheet>