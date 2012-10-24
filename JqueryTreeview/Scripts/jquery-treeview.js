﻿(function ($) {
    $.widget("roicp.treeview", {
        self: null,

        options: {
            source: null,
            expandPaths: null
        },

        _create: function () {
            self = this;
            self._getChildrenNodes(0, self.element, self._getChildrenNodesCompleted);
        },

        _getChildrenNodes: function (itemId, baseElement, funcCallback) {
            if (typeof self.options.source === "string") {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: self.options.source,
                    data: "{ 'upperId':'" + itemId + "' }",
                    dataType: "json",
                    success: function (data) {
                        funcCallback(itemId, baseElement, data);
                    },
                    error: function () {
                        alert("An error occurred when trying to obtain the nodes");
                    }
                });
            };
        },

        _getChildrenNodesCompleted: function (itemId, parentElement, data) {
            if (data != null && data.length > 0) {
                var childTreeTag = $("<ul />");
                childTreeTag.addClass("treeview");

                self._createNode(data, childTreeTag);

                childTreeTag.appendTo(parentElement);

                self._expandNodesInExpandPaths(self.options.expandPaths);
            }
        },

        _expandNode: function (itemNodeId) {
            var currentNode = self.element.find("li[id='" + itemNodeId + "']").first();

            self._switchCssClass(currentNode.children(".span-expand"));

            self._getChildrenNodes(itemNodeId, currentNode, self._getChildrenNodesCompleted);
        },

        _collapseNode: function (itemNodeId) {
            var currentNode = self.element.find("li[id='" + itemNodeId + "']").first();

            self._switchCssClass(currentNode.children(".span-collapse"));

            currentNode.children("ul").remove();
        },

        _createNode: function (dataSource, parentElement) {
            for (var i = 0; i < dataSource.length; i++) {
                var item = dataSource[i];
                var hitPosition;

                if (dataSource.length == 1) {
                    hitPosition = "hit-single";
                } else {
                    switch (i) {
                        case 0:
                            hitPosition = "hit-first";
                            break;
                        case dataSource.length - 1:
                            hitPosition = "hit-last";
                            break;
                        default:
                            hitPosition = "";
                            break;
                    }
                }

                // Create the base node li tag
                var nodeInnerTag = $("<li />");
                nodeInnerTag.attr("id", item.Id);
                nodeInnerTag.addClass("node-bg-vimage");
                nodeInnerTag.addClass("without-child-node");

                if (item.HasChild) {
                    nodeInnerTag.removeClass("without-child-node").addClass("with-child-node");
                }

                if (hitPosition == "hit-last" || hitPosition == "hit-single") {
                    nodeInnerTag.removeClass("node-bg-vimage");
                }

                // Create the span hit area (where the plus and minus sign appears)
                var nodeSpanHit = $("<span />");
                nodeSpanHit.attr("id", item.Id);
                nodeSpanHit.addClass("no-hit-area");

                if (item.HasChild) {
                    nodeSpanHit.removeClass("no-hit-area").addClass("span-expand").addClass("hit-area");

                    nodeSpanHit.bind("click", function () {
                        self._expandNode($(this).attr("id"));
                    });
                }

                nodeSpanHit.addClass(hitPosition);
                nodeSpanHit.appendTo(nodeInnerTag);

                // Create a span to be used as a render node container.
                // The content of this container could be overridden by a custom _renderItem method.
                var spanText = $("<span />");
                spanText.addClass("span-node-render-container");
                spanText.data("treeview-render-container-item", item);
                self._renderItem(spanText, item);
                spanText.appendTo(nodeInnerTag);

                // Attaching the new node to the parent element
                nodeInnerTag.appendTo(parentElement);
            }
        },

        _renderItem: function (spanText, item) {
            var spanName = $("<span />");
            spanName.addClass("span-node-text");
            spanName.html(item.Name);
            spanName.appendTo(spanText);
        },

        _switchCssClass: function (workNode) {
            workNode.unbind('click');

            if (workNode.hasClass("span-collapse")) {
                workNode.removeClass("span-collapse").addClass("span-expand");

                workNode.bind("click", function () {
                    self._expandNode($(this).attr("id"));
                });
            } else {
                if (workNode.hasClass("span-expand")) {
                    workNode.removeClass("span-expand").addClass("span-collapse");

                    workNode.bind("click", function () {
                        self._collapseNode($(this).attr("id"));
                    });
                }
            }
        },

        _expandNodesInExpandPaths: function (itens) {
            if ($.isArray(itens)) {
                $(itens).each(function (index, value) {
                    if ($.isArray(this)) {
                        self._expandNodesInExpandPaths(this);
                    } else {
                        
                    }
                });
            }
        },

        _setOption: function (key, value) {
            self._super(key, value);

            if (key === "source") {
                self._getChildrenNodes(0, self.element, self._getChildrenNodesCompleted);
            }

            if (key === "expandPaths") {
                self._expandNodesInExpandPaths(self.options.expandPaths);
            }
        },

        destroy: function () {
            $.Widget.prototype.destroy.call(this);
        }
    });
})(jQuery);